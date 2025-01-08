using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Helper
{
    public static class FileHelper
    {
        public static string SaveFile(this IFormFile file, string rootpath, string folder)
        {
            string FileName = Guid.NewGuid().ToString() + file.FileName;
            string FullPath = Path.Combine(rootpath, folder, FileName);

            using (FileStream fs = new FileStream(FullPath, FileMode.Create))
            {
                file.CopyTo(fs);
            };

            return FileName;
        }

        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("image");
        }

        public static bool IsSizeOk(this IFormFile file, int mb)
        {
            double length = ((double)(file.Length / 1024) / 1024);
            return length > mb;
        }

        public static void RmoveFile(this IFormFile file, string webRootPath, string folder)
        {
            File.Delete(Path.Combine(webRootPath, folder, file.FileName));
        }
    }
}
