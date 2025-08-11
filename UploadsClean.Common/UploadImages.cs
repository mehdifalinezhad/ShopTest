using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace UploadsClean.Common
{
    public static class UploadImages
    {
        public static string SaveImage(IFormFile file, string DirectoryName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory() + @"\wwwroot" + @$"\{DirectoryName}\");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string SaveName = Guid.NewGuid().ToString() + file.FileName;
            var SavedUrl = $"/{DirectoryName}/{SaveName}";
            var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", DirectoryName)).Root + $@"\{SaveName}";

            using (FileStream fs = File.Create(filepath))
            {
               file.CopyTo(fs);
                fs.Flush();
            }

            return SavedUrl;
        }
        //public string CreateThumbImage(IFormFile file, string DirectoryName)
        //{
        //    try
        //   {
        //        FileStream thumbnailImage =GetThumbnailImage(DirectoryName, () => false, IntPtr.Zero);

        //        string webroot = host.WebRootPath;

        //        string DesiredDirectoryLocation = Path.Combine(webroot, desiredThumbPath);

        //        if (!Directory.Exists(DesiredDirectoryLocation))
        //        {
        //            Directory.CreateDirectory(DesiredDirectoryLocation);
        //        }

        //        string thumbFullPathName = desiredThumbPath + "/" + desiredThumbFilename;
        //       thumbnailImage.Save(thumbFullPathName);

        //        return thumbFullPathName;
        //   }
        //   catch
        //    {
        //       throw;
        //    }

        //}
        public static string SaveImageLow(IFormFile file, string DirectoryName)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory() + @$"\wwwroot\{DirectoryName}");

            if (Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string pathName = Guid.NewGuid().ToString() + file.FileName;
            var fullpath = $"{path}/{pathName}";
           var thePath = new PhysicalFileProvider(Path.Combine(path)).Root + $@"\{pathName}";
            using (FileStream fs = File.Create(thePath,100))
            {
                file.CopyTo(fs);
                fs.Flush();

            }

            return fullpath;
        }
    }
}
