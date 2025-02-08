using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using StayFit.Application.Abstracts.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Infrastructure.Concretes.Services.Storage.Azure
{
    public class AzureStorageService : Storage, IAzureStorage
    {
        private readonly BlobServiceClient _blobServiceClient;
        private BlobContainerClient _blobContainerClient;

        public AzureStorageService(IConfiguration configuration)
        {
            _blobServiceClient = new(configuration["Storage:Azure"]);
        }

        public async Task DeleteAsync(string containerName, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            BlobClient blobClient = _blobContainerClient.GetBlobClient(fileName);
            await blobClient.DeleteAsync();
        }

        public List<string> GetFiles(string containerName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            return _blobContainerClient.GetBlobs().Select(x => x.Name).ToList();
        }

        public bool HasFile(string containerName, string fileName)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            return _blobContainerClient.GetBlobs().Any(x => x.Name == fileName);
        }

        public async Task<List<(string fileName, string PathOrContainerName)>> UploadAsync(string containerName, IFormFileCollection files)
        {
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
            await _blobContainerClient.CreateIfNotExistsAsync();
            await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.BlobContainer);
            List<(string fileName, string PathOrContainerName)> datas = new();
            foreach (IFormFile file in files)
            {
                string newFileName = await FileRenameAsync(containerName, file.FileName, HasFile);
                BlobClient blobClient = _blobContainerClient.GetBlobClient(newFileName);
                await blobClient.UploadAsync(file.OpenReadStream());
                datas.Add((newFileName, $"{containerName}/{newFileName}"));
            }
            return datas;
        }
    }
}
