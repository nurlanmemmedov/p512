using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace P512FiorelloBack.Utils
{
    public class FileUtils
    {
        public static string Create(string folderPath, IFormFile file)
        {
            var fileName = Guid.NewGuid() + file.FileName;
            var fullPath = Path.Combine(folderPath, fileName);

            FileStream stream = new FileStream(fullPath, FileMode.Create);
            file.CopyTo(stream);
            stream.Close();
            return fileName;
        }

        public static void Delete(string fullPath)
        {
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
    }
}
