using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayFit.Infrastructure.Concretes.Services.Storage
{
    public class Storage
    {
        protected delegate bool HasFile(string pathOrContainerName, string fileName);
        protected async Task<string> FileRenameAsync(string pathOrContainerName, string fileName, HasFile hasFileMethod)
        {
            var fileExtension = Path.GetExtension(fileName);
            var fileWithoutExtension = Path.GetFileNameWithoutExtension(fileName);

            var newFileName = fileName;
            var newFilePath = Path.Combine(pathOrContainerName, newFileName);
            int counter = 1;

            while (hasFileMethod(pathOrContainerName, newFileName))
            {
                newFileName = $"{fileWithoutExtension}-{counter}{fileExtension}";
                newFilePath = Path.Combine(pathOrContainerName, newFileName);
                counter++;
            }

            return await Task.FromResult(newFileName);
        }
    }
}
