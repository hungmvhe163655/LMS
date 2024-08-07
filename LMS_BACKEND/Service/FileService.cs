﻿using Amazon.S3;
using Amazon.S3.Model;
using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;
using Shared.GlobalVariables;
using System.IO.Compression;
using System.Net;

namespace Service
{
    public class FileService : IFileService
    {
        private readonly IAmazonS3 _s3Client;
        private readonly string? _bucketName;
        private readonly IMapper _mappers;
        private readonly IRepositoryManager _repositoryManager;
        public FileService(IAmazonS3 s3Client, IConfiguration configuration, IMapper mapper, IRepositoryManager repository)
        {
            _s3Client = s3Client;
            _bucketName = configuration["AWS:BucketName"];
            _mappers = mapper;
            _repositoryManager = repository;
        }
        private static readonly HashSet<string> ImageMimeTypes = new HashSet<string>
        {
            "image/jpeg",
            "image/png",
            "image/gif",
            "image/bmp",
            "image/tiff",
            "image/svg+xml",
            "image/webp"
        };
        public static bool IsImageMimeType(string mimeType)
        {
            if (string.IsNullOrEmpty(mimeType))
            {
                return false;
            }

            return ImageMimeTypes.Contains(mimeType.ToLowerInvariant());
        }

        private async Task DeleteFileFromS3Async(string key)
        {
            DeleteObjectRequest request = new()
            {
                BucketName = _bucketName,
                Key = key
            };
            await _s3Client.DeleteObjectAsync(request);
        }
        private bool IsFileExists(string key)
        {
            try
            {
                GetObjectMetadataRequest request = new()
                {
                    BucketName = _bucketName,
                    Key = key
                };

                var response = _s3Client.GetObjectMetadataAsync(request).Result;

                return true;
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException is AmazonS3Exception awsEx)
                {
                    if (string.Equals(awsEx.ErrorCode, "NoSuchBucket"))
                        return false;

                    else if (string.Equals(awsEx.ErrorCode, "NotFound"))
                        return false;
                }

                throw;
            }
        }
        private async Task<PutObjectResponse> UploadFileToS3Async(string Key, string contentType, Stream inputStream)
        {
            var putRequest = new PutObjectRequest
            {
                BucketName = _bucketName,
                Key = Key,
                InputStream = inputStream,
                ContentType = contentType,
                DisablePayloadSigning = true
            };

            var response = await _s3Client.PutObjectAsync(putRequest);
            return response;
        }

        private async Task<byte[]> GetFileFromS3Async(string key)
        {
            MemoryStream ms;

            GetObjectRequest getObjectRequest = new()
            {
                BucketName = _bucketName,
                Key = key
            };

            using (var response = await _s3Client.GetObjectAsync(getObjectRequest))
            {
                if (response.HttpStatusCode == HttpStatusCode.OK)
                {
                    using (ms = new MemoryStream())
                    {
                        await response.ResponseStream.CopyToAsync(ms);
                    }
                    if (ms == null || ms.ToArray().Length < 1) throw new BadRequestException(string.Format("The document '{0}' is not found", key));

                    return ms.ToArray();
                }
            }
            throw new BadRequestException("Error while getting file from R2");


        }

        private async Task<Dictionary<string, string>> GetFileMetaDataWithKeyAsync(List<Guid> fileIds)
        {
            return await _repositoryManager.File
                                    .GetByCondition(x => fileIds.Contains(x.Id), false)
                                    .ToDictionaryAsync(f => f.FileKey, f => f.Name);
        }

        public async Task<byte[]> DownloadAndZipFilesFromS3Async(Dictionary<string, string> fileMetadata)
        {
            var zipStream = new MemoryStream();

            using (var archive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
            {
                foreach (var kvp in fileMetadata)
                {
                    var fileKey = kvp.Key;

                    var originalFileName = kvp.Value;

                    var request = new GetObjectRequest
                    {
                        BucketName = _bucketName,
                        Key = fileKey
                    };

                    using (var response = await _s3Client.GetObjectAsync(request))
                    using (var entryStream = response.ResponseStream)
                    {
                        var entry = archive.CreateEntry(originalFileName);

                        using (var entryFileStream = entry.Open())
                        {
                            await entryStream.CopyToAsync(entryFileStream);
                        }
                    }
                }
            }

            zipStream.Position = 0;

            return zipStream.ToArray();
        }

        private async Task<Files> FindFileById(Guid id)
        {
            var end = await _repositoryManager.File.GetFile(id, false).FirstOrDefaultAsync();

            if (end == null) throw new BadRequestException("No File With that Id was found");

            if (!IsFileExists(end.FileKey)) throw new BadRequestException("File with such key doesn't exist");

            return end;
        }

        public async Task DeleteFile(Guid id)
        {
            var hold_file = await FindFileById(id);

            await DeleteFileFromS3Async(hold_file.FileKey);

            _repositoryManager.File.Delete(hold_file);

            await _repositoryManager.Save();
        }
        public async Task<FileResponseModel> CreateFile(FileUploadRequestModel model, Stream inputStream)
        {
            if (model.MimeType.Equals("application/octet-stream")) throw new BadRequestException("Invalid file type");

            model.FileKey = Guid.NewGuid().ToString();

            var hold = _mappers.Map<Files>(model);

            hold.Id = Guid.NewGuid();

            await _repositoryManager.File.CreateFile(hold);

            var result = await UploadFileToS3Async(model.FileKey, model.MimeType, inputStream);

            if (result.HttpStatusCode != HttpStatusCode.OK) { throw new Exception("Add File Failed due to AWS: " + result.HttpStatusCode); }

            await _repositoryManager.Save();

            return _mappers.Map<FileResponseModel>(hold);
        }
        public async Task<(byte[], FileResponseModel)> GetFile(Guid fileID)
        {
            var hold_file = await FindFileById(fileID);

            var hold = await GetFileFromS3Async(hold_file.FileKey ?? throw new Exception("Not found File key"));

            var hold_return_model = _mappers.Map<FileResponseModel>(hold_file);

            hold_return_model.FolderPath = _repositoryManager.FolderClosure.GetBranch(hold_file.FolderId, false).ToString() ?? "";

            return (hold, hold_return_model);
        }
        public async Task<byte[]> DownloadFile(string fileKey)//download images
        {
            var hold = await GetFileFromS3Async(fileKey ?? throw new BadRequestException("Not found File key"));

            return hold;
        }
        public async Task<string> UploadFile(Stream inputStream, string mime, string type)//upload images
        {
            if (!type.ToLower().Equals(IMAGE_TYPE.DEVICE.ToLower()) && !type.ToLower().Equals(IMAGE_TYPE.REPORT.ToLower())) throw new BadRequestException("Not a valid purpose");

            if (!IsImageMimeType(mime)) throw new BadRequestException("Only pictures allowed");

            var file_key = Guid.NewGuid().ToString();

            var hold = new Images { Id = file_key, Extentions = mime, Type = type.ToLower().Equals(IMAGE_TYPE.DEVICE.ToLower()) ? IMAGE_TYPE.DEVICE : IMAGE_TYPE.REPORT, Name = file_key };

            _repositoryManager.Image.Create(hold);

            await _repositoryManager.Save();

            var result = await UploadFileToS3Async(file_key, mime, inputStream);

            if (result.HttpStatusCode != HttpStatusCode.OK) { throw new Exception("Add File Failed due to AWS: " + result.HttpStatusCode); }

            return file_key;
        }

        public async Task<FolderResponseModel> GetFolderWithId(Guid folderId)
        {
            var hold = await _repositoryManager.Folder.GetFolder(folderId, false);

            return _mappers.Map<FolderResponseModel>(hold);
        }

        public async Task RemoveFile(string fileKey)//delete images
        {
            var hold = await _repositoryManager.Image.GetByCondition(x => x.Id.Equals(fileKey), false).FirstOrDefaultAsync();

            _repositoryManager.Image.Delete(hold ?? throw new BadRequestException("No such Image exist"));

            await DeleteFileFromS3Async(fileKey);

            await _repositoryManager.Save();
        }
        public async Task EditFile(FileEditRequestModel model)
        {
            var hold = _mappers.Map<Files>(model);

            _repositoryManager.File.Update(hold);

            await _repositoryManager.Save();

        }
        public async Task<(byte[] Data, string FileName)> DownloadMultipleFiles(List<Guid> files)
        {
            var hold_metadata = await GetFileMetaDataWithKeyAsync(files);

            var end = await DownloadAndZipFilesFromS3Async(hold_metadata);

            return (end, "zipped");
        }

        public async Task<(byte[] Data, string FileName)> DownloadFolder(Guid id)
        {
            var hold_folder = await _repositoryManager.Folder.GetByCondition(x => x.Id.Equals(id), false).FirstOrDefaultAsync() ?? throw new BadRequestException("Folder doest existed");

            var hold = (await _repositoryManager.File.GetByCondition(x => x.FolderId.Equals(id), false).ToListAsync()).Select(x => x.Id).ToList() ?? throw new BadRequestException("Folder don't exist or empty");

            var hold_metadata = await GetFileMetaDataWithKeyAsync(hold);

            var end = await DownloadAndZipFilesFromS3Async(hold_metadata);

            return (end, hold_folder.Name ?? "Zipped");
        }

        public async Task EditFolder(Guid id, FolderEditRequestModel model)
        {
            var hold = await _repositoryManager.Folder.GetByCondition(x => x.Id.Equals(id), true).FirstOrDefaultAsync() ?? throw new BadRequestException("Invalid Folder Id");

            _mappers.Map(model, hold);

            await _repositoryManager.Save();
        }

        public async Task<List<FolderBranchDisplayResponseModel>> GetRootWithProjectId(Guid projectId)
        {
            var root = await _repositoryManager.Folder.GetRootByProjectId(projectId).FirstOrDefaultAsync() ?? throw new Exception("Project associated with that ID currently doesn't have a root");

            var hold_folder_branch = await _repositoryManager.FolderClosure.GetProjectFoldersByRoot(root.Id, false);

            var folders = new List<FolderBranchDisplayResponseModel>();

            foreach (var item in hold_folder_branch)
            {
                var mid = await _repositoryManager.Folder.GetFolder(item.DescendantID, false);

                folders.Add(new FolderBranchDisplayResponseModel { Id = mid.Id, Name = mid.Name, Depth = item.Depth });
            }
            return folders;
        }

        public async Task<(GetFolderContentResponseModel Data, int? Cursor)> GetFolderContent(FolderRequestParameters param, Guid folderID)
        {
            var hold_folders = await (await _repositoryManager.Folder.GetFolderWithDescendantDepth1Id_NoPaged(param.OrderBy, folderID)).ToListAsync();

            var end_folders = hold_folders.Skip(param.Cursor ?? SCROLL_LIST.DEFAULT_TOP).Take(param.Take ?? SCROLL_LIST.TINY10).ToList();

            var hold_files = await _repositoryManager.File.GetFileWithFolderId_NoPaged(param.OrderBy, folderID).ToListAsync();

            int taken = end_folders.Count + (param.Cursor ?? SCROLL_LIST.DEFAULT_TOP);

            if (!end_folders.Any() || end_folders.Count < (param.Take ?? SCROLL_LIST.TINY10))
            {
                var new_skip = (param.Cursor ?? SCROLL_LIST.DEFAULT_TOP) - hold_folders.Count;

                var remain_take = (param.Take ?? SCROLL_LIST.TINY10) - end_folders.Count();

                var end_files = hold_files.Skip(new_skip).Take(remain_take).ToList();

                taken += end_files.Count;

                return (new GetFolderContentResponseModel { Files = _mappers.Map<List<FileResponseModel>>(end_files), Folders = _mappers.Map<List<FolderResponseModel>>(end_folders) }, hold_folders.Count + hold_files.Count > taken ? taken : null);
            }

            return (new GetFolderContentResponseModel { Folders = _mappers.Map<List<FolderResponseModel>>(end_folders) }, hold_folders.Count + hold_files.Count > taken ? taken : null);



            /*
            var hold_file = await _repositoryManager.File.GetFiles(false, folderID);

            var end = hold_file.ToList();

            var hold_folder_branch = _repositoryManager.FolderClosure.GetFolderContent(folderID, false);

            var folders = new List<Folder>();

            foreach (var item in hold_folder_branch) folders.Add(await _repositoryManager.Folder.GetFolder(item.DescendantID, false));

            return new GetFolderContentResponseModel { Files = end, Folders = folders };
            */

        }

        public async Task<(IEnumerable<FolderResponseModel> Data, int? Cursor)> GetFolderFolders(FolderRequestParameters param, Guid folderID)
        {
            var folders = await _repositoryManager.Folder.GetFolderWithDescendantDepth1Id(param, folderID);

            return (_mappers.Map<IEnumerable<FolderResponseModel>>(folders.Data), folders.Cursor);
        }

        public async Task<(IEnumerable<FileResponseModel> Data, int? Cursor)> GetFolderFiles(FilesRequestParameters param, Guid folderID)
        {
            var hold_file = await _repositoryManager.File.GetFileWithFolderId(param, folderID);

            return (_mappers.Map<IEnumerable<FileResponseModel>>(hold_file.Data), hold_file.Cursor);
        }

        public async Task<FolderResponseModel> CreateFolder(CreateFolderRequestModel model, string userId, Guid AncestorId)
        {
            if (AncestorId == Guid.Empty) throw new BadRequestException("AncestorId can not be null");

            var hold_father = await _repositoryManager.Folder.GetByCondition(x => x.Id.Equals(AncestorId), false).FirstOrDefaultAsync() ?? throw new BadRequestException("Invalid FolderID");

            var hold_ancs = await _repositoryManager.FolderClosure.FindAncestors(AncestorId, true).ToListAsync() ?? throw new BadRequestException("Create a root folder is not allowed");

            var hold_folder = new Folder
            {
                Id = Guid.NewGuid(),
                CreatedBy = userId,
                ProjectId = hold_father.ProjectId,
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                Name = model.Name
            };

            var end = new List<FolderClosure>();

            foreach (var item in hold_ancs)
            {
                end.Add(new FolderClosure { AncestorID = item.AncestorID, DescendantID = hold_folder.Id, Depth = item.Depth + 1 });
            }
            end.Add(new FolderClosure { AncestorID = hold_folder.Id, DescendantID = hold_folder.Id, Depth = 0 });

            await _repositoryManager.Folder.AddFolder(hold_folder);

            await _repositoryManager.FolderClosure.AddRange(end);

            await _repositoryManager.Save();

            return _mappers.Map<FolderResponseModel>(hold_folder);
        }
        /*
        public async Task DeleteFolder(Guid folderID)
        {
            var hold_folder = await _repositoryManager.Folder.GetFolder(folderID, false);

            var hold_files = _repositoryManager.File.FindAll(false).Where(x => x.FolderId.Equals(folderID));

            var hold_folderClosure_descendant = _repositoryManager.FolderClosure.FindDescendants(folderID, false);

            var descendants_ancestors = new List<FolderClosure>();

            foreach (var item in hold_folderClosure_descendant)
            {
                descendants_ancestors.AddRange(_repositoryManager.FolderClosure.FindAncestors(item.DescendantID, false));
            }
            _repositoryManager.FolderClosure.DeleteListFolder(descendants_ancestors);

            _repositoryManager.File.DeleteRange(hold_files);

            await _repositoryManager.Save();
        }
        */
        public async Task DeleteFolder(Guid folderID)
        {
            var FolderToDelete = new List<Guid>();

            var descendants_ancestors = new List<FolderClosure>();

            var hold_folder = await _repositoryManager.Folder.GetFolder(folderID, false) ?? throw new BadRequestException("Not a valid folder ID");

            if (hold_folder.IsRoot) throw new BadRequestException("Can not delete root folder");

            var hold_folderClosure_descendant = _repositoryManager.FolderClosure.FindDescendants(folderID, false).Select(x => x.DescendantID);

            var descendants = _repositoryManager.Folder.GetByCondition(x => hold_folderClosure_descendant.Contains(x.Id), false);

            foreach (var item in hold_folderClosure_descendant)
            {
                descendants_ancestors.AddRange(await _repositoryManager.FolderClosure.FindAncestors(item, false).ToListAsync());
            }

            FolderToDelete.AddRange(hold_folderClosure_descendant);

            var hold_files = await _repositoryManager.File.FindAll(false).Where(x => FolderToDelete.Contains(x.FolderId)).ToListAsync();

            _repositoryManager.File.DeleteRange(hold_files);

            _repositoryManager.FolderClosure.DeleteListFolder(descendants_ancestors);

            _repositoryManager.Folder.DeleteRange(await descendants.ToListAsync());

            await _repositoryManager.Save();
        }
        public async Task AttachToTask(Guid taskId, Guid fileID)
        {
            var task = await _repositoryManager.Task.GetTaskWithId(taskId, true).FirstOrDefaultAsync() ?? throw new BadRequestException("Not found task with that ID");

            var file = await _repositoryManager.File.GetFile(fileID, true).FirstOrDefaultAsync() ?? throw new BadRequestException("Not found file with that ID");

            task.Files.Add(file);

            file.Tasks.Add(task);

            await _repositoryManager.Save();
        }

        public async Task MoveFileToFolder(Guid fileId, Guid newFolderID)
        {
            var file = await _repositoryManager.File.GetFile(fileId, true).FirstOrDefaultAsync() ?? throw new BadRequestException("Invalid fileid");

            var hold_folder = await _repositoryManager.Folder.GetFolder(file.FolderId, false);

            var project_folders = await _repositoryManager.Folder.GetFoldersByProjectId(hold_folder.ProjectId, false).Select(y => y.Id).ToListAsync() ?? throw new Exception($"Internalerror {nameof(MoveFileToFolder)}");

            if (!project_folders.Contains(newFolderID)) throw new BadRequestException("Destination id is invalid or folder doesn't beloging in the same project");

            file.FolderId = newFolderID;

            await _repositoryManager.Save();
        }
    }
}
