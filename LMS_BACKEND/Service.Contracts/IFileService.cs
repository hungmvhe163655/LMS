using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;

namespace Service.Contracts
{
    public interface IFileService
    {
        Task CreateFile(FileUploadRequestModel model, Stream inputStream);
        Task<(byte[], FileResponseModel)> GetFile(Guid fileID);
        Task<byte[]> DownloadFile(string fileKey);
        Task EditFile(FileEditRequestModel model);
        Task DeleteFile(Guid id);
        Task EditFolder(FolderEditRequestModel model);
        Task<GetFolderContentResponseModel> GetFolderContent(Guid folderID);
        Task<bool> CreateFolder(CreateFolderRequestModel model);
        Task DeleteFolder(Guid folderID);
    }

}
