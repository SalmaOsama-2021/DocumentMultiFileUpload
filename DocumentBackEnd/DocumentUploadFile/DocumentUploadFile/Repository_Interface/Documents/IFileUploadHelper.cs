using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentUploadFile.Repository_Interface.Documents
{
    public interface IFileUploadHelper
    {
        Task<string> Upload(IFormFile objFile, string path);
    }
}
