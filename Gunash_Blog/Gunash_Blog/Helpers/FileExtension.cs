using Microsoft.AspNetCore.Routing.Constraints;

namespace Gunash_Blog.Helpers
{
    public static class FileExtension
    {
        public static async Task<string> Save (this IFormFile file, string path)
        {
            string extension = Path.GetExtension(file.FileName);
            string fileName = Path.GetFileName(file.FileName).Length > 16 ? file.FileName.Substring(0,16) : Path.GetFileName(file.FileName);
            fileName = Path.Combine(path, Path.GetRandomFileName() + fileName +extension);
            using (FileStream fs = File.Create(Path.Combine(ImagesPath.RootPath, fileName)))
            {
                await file.CopyToAsync(fs);
            }
            return fileName;
        }
    }
}
