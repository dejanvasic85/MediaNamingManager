namespace MediaNamingManager
{
    public static class StringExtensions
    {
        public static string FileExtension(this string fileName)
        {
            var idx = fileName.LastIndexOf('.');
            return fileName.Substring(idx);
        }
    }
}