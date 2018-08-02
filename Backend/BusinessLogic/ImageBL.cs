namespace Backend.BusinessLogic
{
    using Backend.Modals;
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

            return new FileStreamResult(new FileStream(filePath, FileMode.Open), mimeType);
        }
    }
}
