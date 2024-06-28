using Shared.DataTransferObjects.RequestDTO;
using Shared.DataTransferObjects.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IFileService
    {
        Task CreateFile(FileUploadRequestModel model, Stream inputStream);
        Task<(Stream, FileResponseModel)> GetFile(string fileID);
        Task<Stream> DownloadFile(string fileKey);
        Task EditFile(FileEditRequestModel model);
        Task EditFolder(FolderEditRequestModel model);
        Task<GetFolderContentResponseModel> GetFolderContent(Guid folderID);
        Task<bool> CreateFolder(CreateFolderRequestModel model);
        Task DeleteFolder(Guid folderID);
    }

}
