using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Helpers
{
    public static class FileHelper
    {
        public static IFormFile Base64ToFormFile(string content, string fileName, string extension)
        {
            var byteArray = Convert.FromBase64String(content);
            var stream = new MemoryStream(byteArray);
            IFormFile file = new FormFile(stream, 0, byteArray.Length, fileName, extension);

            return file;
        }
    }
}
