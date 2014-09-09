using System;
using System.Linq;
using System.Text;

namespace MediaNamingManager
{
    /// <summary>
    /// Parses format of Modern Family S01 Epi01 Pilot.avi
    /// </summary>
    public class EpiInNameParser : IEpisodeParser
    {
        public string RenameToEpisode(int seasonNumber, string originalFileName)
        {
            var episodeNumber = new StringBuilder();
            var indexOfEpiText = originalFileName.IndexOf("Epi", StringComparison.OrdinalIgnoreCase);
            var indexOfEpisodeTextStart = -1;
            var textAfterEpiText = originalFileName.Substring(indexOfEpiText + 3).ToCharArray();
            var episodeNumberParseComplete = false;
            var charactersToIgnoreBeforeEpisodeTitle = new char[] { ' ', '.', '-' };

            // Read next digit
            for (int i = 0; i < textAfterEpiText.Length; i++)
            {
                var str = textAfterEpiText[i].ToString();
                if (!episodeNumberParseComplete)
                {
                    if (!str.IsDigit())
                    {
                        episodeNumberParseComplete = true;
                    }
                    episodeNumber.Append(str);
                    continue;
                }

                if (charactersToIgnoreBeforeEpisodeTitle.Any(c => c == textAfterEpiText[i]))
                    continue;

                // Why 3? Epi.length = 3 and it's a zero based index...
                indexOfEpisodeTextStart = indexOfEpiText + i + 3;
                break;
            }

            if (episodeNumber.Length == 0 || indexOfEpisodeTextStart == -1)
                throw new FormatException("Parsing episode failed in EpiInNameParser Stategy");

            var episodeName = originalFileName.Substring(indexOfEpisodeTextStart);

            var result = string.Format("s{0}e{1} - {2}", seasonNumber.ToFriendlyName(), int.Parse(episodeNumber.ToString()).ToFriendlyName(), episodeName);

            return result;
        }
    }
}