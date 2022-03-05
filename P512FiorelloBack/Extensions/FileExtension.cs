using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P512FiorelloBack.Extensions
{
    public static class FileExtension
    {
        public static bool IsOkay(this IFormFile file)
        {
            return file.ContentType.Contains("image") && file.Length < 1024 * 1024;
        }
    }
}
