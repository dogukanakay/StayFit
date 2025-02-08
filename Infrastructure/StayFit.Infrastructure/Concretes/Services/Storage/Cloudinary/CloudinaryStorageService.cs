using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Npgsql.BackendMessages;
using StayFit.Application.Abstracts.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

public class CloudinaryStorageService : IStorageService
{
    private readonly Cloudinary _cloudinary;
    public string StorageName => "Cloudinary";

    public CloudinaryStorageService(IConfiguration configuration)
    {
        var account = new Account(
            configuration["Storage:Cloudinary:CloudName"],
            configuration["Storage:Cloudinary:ApiKey"],
            configuration["Storage:Cloudinary:ApiSecret"]
        );

        _cloudinary = new Cloudinary(account);
        _cloudinary.Api.Secure = true; 
    }

    public async Task<List<(string fileName, string PathOrContainerName)>> UploadAsync(string folderName, IFormFileCollection files)
    {
        List<(string fileName, string PathOrContainerName)> uploadedFiles = new();

        foreach (var file in files)
        {
            using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Folder = folderName, 
                PublicId = Guid.NewGuid().ToString(), 
                Overwrite = false
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                uploadedFiles.Add((uploadResult.PublicId, uploadResult.SecureUrl.ToString()));
            }
        }

        return uploadedFiles;
    }

    public async Task DeleteAsync(string folderName, string fileName)
    {
        var deleteParams = new DeletionParams($"{folderName}/{fileName}");
        await _cloudinary.DestroyAsync(deleteParams);
    }

    public List<string> GetFiles(string folderName)
    {
        var searchResult = _cloudinary.Search()
            .Expression($"folder:{folderName}")
            .Execute();

        return searchResult.Resources.Select(r => r.PublicId).ToList();
    }

    public bool HasFile(string folderName, string fileName)
    {
        var searchResult = _cloudinary.Search()
            .Expression($"folder:{folderName} AND public_id:{fileName}")
            .Execute();

        return searchResult.Resources.Any();
    }
}
