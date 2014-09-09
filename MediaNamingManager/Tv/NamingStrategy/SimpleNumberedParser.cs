namespace MediaNamingManager
{
    /// <summary>
    /// Parses format 110.mkv
    /// </summary>
    public class SimpleNumberedParser : IEpisodeParser
    {
        public string RenameToEpisode(int seasonNumber, string originalFileName)
        {
            return string.Format("s{0}e{1}", seasonNumber.ToFriendlyName(), originalFileName.Substring(1));
        }
    }
}