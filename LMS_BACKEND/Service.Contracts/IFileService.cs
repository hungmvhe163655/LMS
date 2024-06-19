using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IFileService
    {
        Task UploadFileToS3Async(string key, Stream inputStream);
        Task<Stream> GetFileFromS3Async(string key);
    }
}
