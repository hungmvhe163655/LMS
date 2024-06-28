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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private async Task<PutObjectResponse> UploadFileToS3Async(string key, Stream inputStream)
        {
            var putRequest = new PutObjectRequest
            {
                BucketName = _bucketName,
                Key = key,
                InputStream = inputStream,
                ContentType = "application/octet-stream"
            };

            var response = await _s3Client.PutObjectAsync(putRequest);
            return response;
        }

        private async Task<Stream> GetFileFromS3Async(string key)
        {
            var request = new GetObjectRequest
            {
                BucketName = _bucketName,
                Key = key
            };

            var response = await _s3Client.GetObjectAsync(request);

            return response.ResponseStream;
        }
        public async Task CreateFile(FileUploadRequestModel model, Stream inputStream)
        {
            var fileKey = Guid.NewGuid().ToString();

            model.FileKey = fileKey;

            var result = await UploadFileToS3Async(fileKey, inputStream);
            if (result != null) { throw new NotFoundException("NOT FOUND FILE"); }

            await _repositoryManager.file.CreateFile(_mappers.Map<Files>(model));

            await _repositoryManager.Save();
        }
        public async Task<(Stream, FileResponseModel)> GetFile(string fileID)
        {
            var hold_FileDB = await _repositoryManager.file.GetFiles(false);

            var end = hold_FileDB.Where(x => x.Id.Equals(fileID)).First();

            if (end == null) throw new BadRequestException("No File With that Id was found");

            var hold = await GetFileFromS3Async(end.FileKey ?? throw new Exception("Not found File key"));

            var hold_return_model = _mappers.Map<FileResponseModel>(hold_FileDB);

            hold_return_model.FolderPath = _repositoryManager.folderClosure.GetBranch(end.FolderId, false).ToString() ?? "";

            return (hold, hold_return_model);
        }
        public async Task<Stream> DownloadFile(string fileKey)
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
                var hold = new List<FolderClosure>();

                hold.Add(new FolderClosure { AncestorID = hold_folder.Id, DescendantID = hold_folder.Id, Depth = 0 });

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
