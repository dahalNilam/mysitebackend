namespace Backend.BusinessLogic
{
    using Backend.Modals;
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

        public static async void Upload(IFormFile file)
        {
            var filePath = Path.Combine(BasePath, file.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
        }
    }
}
