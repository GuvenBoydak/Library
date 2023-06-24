namespace Library.MvcUi.Helper
{
    public static class FileHelper
    {
        public static string Add(IFormFile file, string root)
        {
            if (!Directory.Exists(root))
                Directory.CreateDirectory(root);

            string extension = Path.GetExtension(file.FileName);
            string imageName = Guid.NewGuid().ToString() + extension; 

            using (FileStream fileStream = File.Create(root + imageName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();                
            }

            return imageName;
        }
    }
}
