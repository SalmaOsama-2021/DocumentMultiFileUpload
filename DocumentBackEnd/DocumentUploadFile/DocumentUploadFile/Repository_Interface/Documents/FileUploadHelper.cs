using Microsoft.AspNetCore.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace DocumentUploadFile.Repository_Interface.Documents
{
    public class FileUploadHelper : IFileUploadHelper
    {
        public static IHostingEnvironment _environment;
        public FileUploadHelper(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        public async Task<string> Upload(IFormFile objFile, string path)
        {
            try
            {
                if (objFile != null && objFile.Length > 0)
                {
                    if (!Directory.Exists(_environment.ContentRootPath + path))
                    {
                        Directory.CreateDirectory(_environment.ContentRootPath + path);
                    }
                    var fileName = Guid.NewGuid() + Path.GetExtension(objFile.FileName);
                    string targetPath = _environment.ContentRootPath + "\\" + path.Replace("/", "\\") + "\\" + fileName;
                    using (FileStream fileStream = System.IO.File.Create(targetPath))
                    {
                        await objFile.CopyToAsync(fileStream);
                        fileStream.Flush();
                        return path + "/" + fileName;
                    }
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }

    }
}
