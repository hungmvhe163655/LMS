using Entities.Models;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.RequestParameters;
using Shared.DataTransferObjects.ResponseDTO;

namespace Service.Contracts
{
    public interface IFileService
    {
        Task<FileResponseModel> CreateFile(FileUploadRequestModel model, Stream inputStream);
        Task<(byte[], FileResponseModel)> GetFile(Guid fileID);
        Task<FolderResponseModel> GetFolderWithId(Guid folderId);
        Task<(IEnumerable<FolderResponseModel> Data, int DataLeft)> GetFolderFolders(FolderRequestParameters param, Guid folderID);
        Task<(byte[] Data, string FileName)> DownloadFolder(Guid id);
        Task<(IEnumerable<FileResponseModel> Data, int CountLeft)> GetFolderFiles(FilesRequestParameters param, Guid folderID);
        Task EditFile(FileEditRequestModel model);
        Task DeleteFile(Guid id);
        Task EditFolder(FolderEditRequestModel model);
        Task<GetFolderContentResponseModel> GetFolderContent(Guid folderID);
        Task<List<FolderBranchDisplayResponseModel>> GetRootWithProjectId(Guid projectId);
        Task<FolderResponseModel> CreateFolder(CreateFolderRequestModel model);
        Task DeleteFolder(Guid folderID);
        Task AttachToTask(Guid taskId, Guid fileID);
        Task<string> UploadFile(Stream inputStream, string mime, string type);
        Task<byte[]> DownloadFile(string fileKey);
        Task RemoveFile(string fileKey);
    }

}
