using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
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
        public FileService(IAmazonS3 s3Client, IConfiguration configuration)
        {
            _s3Client = s3Client;
            _bucketName = configuration["AWS:BucketName"];
        }
        public async Task UploadFileToS3Async(string key, Stream inputStream)
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

        public async Task<Stream> GetFileFromS3Async(string key)
        {
            var request = new GetObjectRequest
            {
                BucketName = _bucketName,
                Key = key
            };

            var response = await _s3Client.GetObjectAsync(request);

            return response.ResponseStream;
        }
    }
}
