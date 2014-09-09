using System.Linq;

namespace MediaNamingManager
{
    /// <summary>
    /// Parses format 4-02 Remains to be Seen.avi
    /// </summary>
    public class SeasonDashNumberAndNameParser : IEpisodeParser
    {
        public string RenameToEpisode(int seasonNumber, string originalFileName)
        {
            // Strip out the season number
            var stripped = originalFileName.Substring(originalFileName.IndexOf('-') + 1);

            // Fetch the next two characters that should be the episode number
            var episodeNumber = stripped.Substring(0, 2);

            var episodeName = stripped.Substring(2, stripped.Length - 2).Trim();

            return string.Format("s{0}e{1} - {2}", seasonNumber.ToFriendlyName(), episodeNumber, episodeName);
        }
    }
}