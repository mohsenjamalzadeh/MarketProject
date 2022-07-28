using _01_Framework.Application;

namespace ServiceHost
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public FileUploader(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }


        public async Task<string> UploadAsync(IFormFile file, string path)
        {
            if (file == null) return "";

            var directoryPath = $"{_hostEnvironment.WebRootPath}//Uploads//{path}";

            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);

            var fileName = $"{DateTime.Now.ToFileTime()}-{file.FileName}";

            var filepath = directoryPath + fileName;

           await using var output = File.Create(filepath);

            await file.CopyToAsync(output);

            return $"{path}/{fileName}";
        }

        public Task<List<string>> UploadFilesAsync(List<IFormFile> files, string path)
        {
            if (files.Count == 0) return Task.FromResult(new List<string>());

            var directoryPath = $"{_hostEnvironment.WebRootPath}//Uploads//{path}";

            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);

            List< string> fileNames=new List<string>();
            foreach (var file in files)
            {
                var filename= $"{DateTime.Now.ToFileTime()}-{file.Name}";
                fileNames.Add(filename);
            }

            List<string> filePaths = new List<string>();
            foreach (var filename in fileNames)
            {
                var filepath= directoryPath + filename;
                filePaths.Add(filepath);
            }

            foreach (var outPath in filePaths)
            {
                using var output = (File.Create(outPath));
                foreach (var file in files)
                {
                    file.CopyToAsync(output);
                }
            }

            List<string> result = new List<string>();
            foreach (var item in fileNames)
            {
                var res = path + item;
                result.Add(res);
            }

            return Task.FromResult(result);
        }
    }
}
