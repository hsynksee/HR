using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.FileUploader.Models
{
    public class UploadModel
    {
        public IFormFile File { get; set; }
        public string Folder { get; set; }
        public string FileName { get; set; }
        public string UploadPath { get; set; }
        public string ReturnDomain { get; set; }
    }
}
