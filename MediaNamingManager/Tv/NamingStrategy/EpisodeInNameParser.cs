using System;
using System.Linq;
using System.Text;

namespace MediaNamingManager
{
    /// <summary>
    /// Parses format of The Office Season 4 Episode 01.avi
    /// </summary>
    public class EpisodeInNameParser : IEpisodeParser
    {
        public string RenameToEpisode(int seasonNumber, string originalFileName)
        {
            var episodeNumber = originalFileName.Substring(originalFileName.IndexOf("Episode", StringComparison.OrdinalIgnoreCase) + 8);

            var result = string.Format("s{0}e{1}", seasonNumber.ToFriendlyName(), episodeNumber);

            return result;
        }
    }
}