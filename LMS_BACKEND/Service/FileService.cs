using Amazon.S3;
using Amazon.S3.Model;
using AutoMapper;
using Contracts.Interfaces;
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
        private async Task UploadFileToS3Async(string key, Stream inputStream)
        {
            var putRequest = new PutObjectRequest
            {
                BucketName = _bucketName,
                Key = key,
                InputStream = inputStream,
                ContentType = "application/octet-stream"
            };

            var response = await _s3Client.PutObjectAsync(putRequest);
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
        public async Task<bool> CreateFile(FileUploadRequestModel model, Stream inputStream)
        {
            var fileKey = Guid.NewGuid().ToString();

            model.FileKey = fileKey;

            await UploadFileToS3Async(fileKey, inputStream);

            await _repositoryManager.file.CreateFile(_mappers.Map<Files>(model));

            await _repositoryManager.Save();

            return true;
        }
        public async Task<(Stream, FileResponseModel)> GetFile(string fileID)
        {
            var hold_FileDB = await _repositoryManager.file.GetFiles(false);

            var end = hold_FileDB.Where(x => x.Id.Equals(fileID)).First();

            var hold = await GetFileFromS3Async(end.FileKey ?? throw new Exception("Not found File key"));

            var hold_return_model = _mappers.Map<FileResponseModel>(hold_FileDB);

            hold_return_model.FolderPath = _repositoryManager.folderClosure.GetBranch(end.FolderId, false).ToString() ?? "";

            return (hold, hold_return_model);
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
        public async Task<bool> CreateFolder(Guid ancs_id, CreateFolderRequestModel model)
        {
            var hold_folder = new Folder { Id = Guid.NewGuid(), CreatedBy = model.CreatedBy, CreatedDate = DateTime.Now, Name = model.Name };

            var hold_ancs = _repositoryManager.folderClosure.FindAncestors(ancs_id, false);

            var hold = new List<FolderClosure>();

            foreach (var item in hold_ancs)
            {
                hold.Add(new FolderClosure { AncestorID = item.AncestorID, DescendantID = hold_folder.Id, Depth = item.Depth + 1 });
            }
            hold.Add(new FolderClosure { AncestorID = hold_folder.Id, DescendantID = hold_folder.Id, Depth = 0 });

            await _repositoryManager.folder.AddFolder(hold_folder);

            await _repositoryManager.folderClosure.AddLeaf(hold);

            await _repositoryManager.Save();

            return true;
        }
        public  async Task<bool> AttachFilesToNews()
        {
            return true;
        }
    }
}
