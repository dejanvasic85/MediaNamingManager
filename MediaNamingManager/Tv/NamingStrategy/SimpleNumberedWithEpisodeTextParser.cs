namespace MediaNamingManager
{
    /// <summary>
    /// Parses format Parks and Recreation - Episode 401 - Im Leslie Knope.avi
    /// </summary>
    public class SimpleNumberedWithEpisodeTextParser : IEpisodeParser
    {
        public string RenameToEpisode(int seasonNumber, string originalFileName)
        {
            var indexOfEpisodeText = originalFileName.IndexOf(string.Format("Episode {0}", seasonNumber));

            var episodeNumber = originalFileName.Substring(indexOfEpisodeText + 9, 2);

            var episodeName = originalFileName.Substring(indexOfEpisodeText + 12);

            return string.Format("s{0}e{1} {2}", seasonNumber.ToFriendlyName(), episodeNumber, episodeName);
        }
    }
}