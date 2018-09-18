namespace Backend.BusinessLogic
{
    using Backend.Modals;
    using Backend.Utilities;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.IO;
    using System.Linq;

    public static class ImageBL
    {
        private static readonly string BasePath = @"E:\Projects\MySite\Images\";

        public static FileStreamResult GetImageFile(Image image)
        {
            var filePath = BasePath + image.FileName;

            var ext = filePath.Split(".").LastOrDefault();

            var mimeType = "image/" + ext;

            return new FileStreamResult(new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite), mimeType);
        }

        public static string GetFilePath(string fileName)
        {
            return Path.Combine(BasePath, fileName);
        }

        public static async void Upload(IFormFile file, string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                await file.CopyToAsync(fileStream);
            }
        }
    }
}
