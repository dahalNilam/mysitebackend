namespace Backend.Utilities
{
    using System;
    using System.IO;
    using System.Security.Cryptography;

    public static class ImageUtils
    {
        public static string GetHash(string fileName)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(fileName))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                }
            }
        }
    }
}
