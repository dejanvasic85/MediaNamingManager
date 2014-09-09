namespace MediaNamingManager
{
    /// <summary>
    /// Parses format Futurama 01x01 - Space Pilot 3000.avi
    /// </summary>
    public class SeasonExEpisodeWithNameParser : IEpisodeParser
    {
        public string RenameToEpisode(int seasonNumber, string originalFileName)
        {
            // Find the first dash
            var dashIndex = originalFileName.IndexOf('-');

            // Episode number
            var episodeNumber = int.Parse( originalFileName.Substring(dashIndex - 3, 2) );

            // Episode name
            var episodeName = originalFileName.Substring(dashIndex);

            var result = string.Format("s{0}e{1} {2}", seasonNumber.ToFriendlyName(), episodeNumber.ToFriendlyName(), episodeName);

            return result;
        }
    }
}