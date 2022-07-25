using Microsoft.AspNetCore.Http;

namespace _01_Framework.Application
{
    public interface IFileUploader
    {
        Task<string>  UploadAsync(IFormFile file, string path);
        Task<List<string>> UploadFilesAsync(List<IFormFile> files, string path);
    }
}
