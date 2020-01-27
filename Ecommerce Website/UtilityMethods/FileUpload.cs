using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Website.UtilityMethods
{
    public static class FileUpload
    {

       public static async Task<string> UploadFile(IFormFile formFile, String folderName) {
            var fileName = DateTime.Now.Ticks.ToString() + formFile.FileName;

            var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                $@"wwwroot\{folderName}", fileName);
            await formFile.CopyToAsync(new FileStream(filePath, FileMode.Create));


            return $"{folderName}\\{fileName}";


        }
    }
}
