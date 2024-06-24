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
        Task<bool> CreateFile(FileUploadRequestModel model, Stream inputStream);
        Task<(Stream,FileResponseRequestModel)> GetFile(string FileID);
    }
}
