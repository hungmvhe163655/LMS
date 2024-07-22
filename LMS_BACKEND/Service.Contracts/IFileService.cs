using Entities.Models;
using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;

namespace Service.Contracts
{
    public interface IFileService
    {
        Task<FileResponseModel> CreateFile(FileUploadRequestModel model, Stream inputStream);
        Task<(byte[], FileResponseModel)> GetFile(Guid fileID);
        Task EditFile(FileEditRequestModel model);
        Task DeleteFile(Guid id);
        Task EditFolder(FolderEditRequestModel model);
        Task<GetFolderContentResponseModel> GetFolderContent(Guid folderID);
        Task<List<FolderBranchDisplayResponseModel>> GetRootWithProjectId(Guid projectId);
        Task<FolderResponseModel> CreateFolder(CreateFolderRequestModel model);
        Task DeleteFolder(Guid folderID);
        Task AttachToTask(Guid taskId, Guid fileID);
        Task<string> UploadFile(Stream inputStream, string mime);
        Task<byte[]> DownloadFile(string fileKey);
        Task RemoveFile(string fileKey);
    }

}
