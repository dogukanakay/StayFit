using Microsoft.AspNetCore.Http;
using StayFit.Application.Abstracts.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Infrastructure.Storage
{
    public class StorageService : IStorageService
    {
        private readonly IStorage _storage;

        public StorageService(IStorage storage)
        {
            _storage = storage;
        }

        public string StorageName { get => _storage.GetType().Name; }

        public async Task DeleteAsync(string path, string fileName)
                 => await _storage.DeleteAsync(path, fileName);


        public List<string> GetFiles(string pathOrContainerName)
                 => _storage.GetFiles(pathOrContainerName);

        public bool HasFile(string pathOrContainerName, string fileName)
                 => _storage.HasFile(pathOrContainerName, fileName);

        public Task<List<(string fileName, string PathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
                 => _storage.UploadAsync(pathOrContainerName, files);
    }
}
