namespace MediaNamingManager
{
    public class SimpleIndexedRenamer : ITvRenamer
    {
        public string RenameToEpisode(int seasonNumber, string originalFileName, int? index = null)
        {
            return string.Format("s{0}e{1}{2}", seasonNumber.ToFriendlyName(), index.Value.ToFriendlyName(), originalFileName.FileExtension());
        }
    }
}