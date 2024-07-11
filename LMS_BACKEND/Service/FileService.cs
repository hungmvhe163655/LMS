using Amazon.S3;
using Amazon.S3.Model;
using AutoMapper;
using Contracts.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
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
        private async Task<(IEnumerable<Files>, Files)> FindFileById(Guid id)
        {
            var hold_FileDB = await _repositoryManager.file.GetFiles(false);

            var end = hold_FileDB.Where(x => x.Id.Equals(id)).ToList();

            if (!end.Any()) throw new BadRequestException("No File With that Id was found");

            var hold_file = end.First();

            if (!IsFileExists(hold_file.FileKey)) throw new BadRequestException("File with such key doesn't exist");

            return (hold_FileDB, hold_file);
        }

        public async Task DeleteFile(Guid id)
        {
            var (_, hold_file) = await FindFileById(id);

            await DeleteFileFromS3Async(hold_file.FileKey);

            _repositoryManager.file.Delete(hold_file);

            await _repositoryManager.Save();
        }
        public async Task CreateFile(FileUploadRequestModel model, Stream inputStream)
        {
            var fileKey = Guid.NewGuid().ToString();

            model.FileKey = fileKey;

            var hold = _mappers.Map<Files>(model);

            hold.Id = Guid.NewGuid();

            var result = await UploadFileToS3Async(fileKey, model.MimeType, inputStream);

            if (result.HttpStatusCode != System.Net.HttpStatusCode.OK) { throw new Exception("Add File Failed due to AWS: " + result.HttpStatusCode); }

            await _repositoryManager.file.CreateFile(hold);

            await _repositoryManager.Save();
        }
        public async Task<(byte[], FileResponseModel)> GetFile(Guid fileID)
        {
            var (_, hold_file) = await FindFileById(fileID);

            var hold = await GetFileFromS3Async(hold_file.FileKey ?? throw new Exception("Not found File key"));

            var hold_return_model = _mappers.Map<FileResponseModel>(hold_file);

            hold_return_model.FolderPath = _repositoryManager.folderClosure.GetBranch(hold_file.FolderId, false).ToString() ?? "";

            return (hold, hold_return_model);
        }
        public async Task<byte[]> DownloadFile(string fileKey)
        {
            var hold = await GetFileFromS3Async(fileKey ?? throw new BadRequestException("Not found File key"));

            return hold;
        }
        public async Task EditFile(FileEditRequestModel model)
        {
            var hold = _mappers.Map<Files>(model);

            _repositoryManager.file.Update(hold);

            await _repositoryManager.Save();

        }
        public async Task EditFolder(FolderEditRequestModel model)
        {
            var hold = _mappers.Map<Folder>(model);

            _repositoryManager.folder.UpdateFolder(hold);

            await _repositoryManager.Save();
        }
        public async Task<GetFolderContentResponseModel> GetFolderContent(Guid folderID)
        {
            var hold_file = await _repositoryManager.file.GetFiles(false);

            var end = hold_file.Where(x => x.FolderId.Equals(folderID)).ToList();

            var hold_folder_branch = _repositoryManager.folderClosure.GetFolderContent(folderID, false);

            var folders = new List<Folder>();

            foreach (var item in hold_folder_branch)
            {
                folders.Add(_repositoryManager.folder.GetFolder(item.DescendantID, false));
            }

            return new GetFolderContentResponseModel { Files = end, Folders = folders };
        }
        public async Task<bool> CreateFolder(CreateFolderRequestModel model)
        {
            var hold_folder = new Folder { Id = Guid.NewGuid(), CreatedBy = model.CreatedBy, CreatedDate = DateTime.Now, LastModifiedDate = DateTime.Now, Name = model.Name };

            await _repositoryManager.folder.AddFolder(hold_folder);

            if (model.AncestorId != Guid.Empty)
            {
                var hold_ancs = _repositoryManager.folderClosure.FindAncestors(model.AncestorId, false);

                var hold = new List<FolderClosure>();

                foreach (var item in hold_ancs)
                {
                    hold.Add(new FolderClosure { AncestorID = item.AncestorID, DescendantID = hold_folder.Id, Depth = item.Depth + 1 });
                }
                hold.Add(new FolderClosure { AncestorID = hold_folder.Id, DescendantID = hold_folder.Id, Depth = 0 });

                await _repositoryManager.folderClosure.AddLeaf(hold);
            }
            else
            {
                var hold = new List<FolderClosure>
                {
                    new FolderClosure { AncestorID = hold_folder.Id, DescendantID = hold_folder.Id, Depth = 0 }
                };

                await _repositoryManager.folderClosure.AddLeaf(hold);
            }

            await _repositoryManager.Save();

            return true;
        }
        public async Task DeleteFolder(Guid folderID)
        {
            var hold_files = _repositoryManager.file.FindAll(false).Where(x => x.FolderId.Equals(folderID));

            var hold_folderClosure_descendant = _repositoryManager.folderClosure.FindDescendants(folderID, false);

            var descendants_ancestors = new List<FolderClosure>();

            foreach (var item in hold_folderClosure_descendant)
            {
                descendants_ancestors.AddRange(_repositoryManager.folderClosure.FindAncestors(item.DescendantID, false));
            }
            _repositoryManager.folderClosure.DeleteListFolder(descendants_ancestors);

            _repositoryManager.file.DeleteRange(hold_files);

            await _repositoryManager.Save();
        }
    }
}
