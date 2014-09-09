namespace MediaNamingManager
{
    /// <summary>
    /// Parses format Seinfeld Episode 01 - wahtevs.mks
    /// </summary>
    public class EpisodeNameAfterDashParser : IEpisodeParser
    {
        public string RenameToEpisode(int seasonNumber, string originalFileName)
        {
            var indexOfFirstDash = originalFileName.IndexOf('-');
            var episodeName = originalFileName.Substring(indexOfFirstDash).Replace("- ", "");
            var episodeNumberSection = originalFileName.Substring(0, indexOfFirstDash);

            // Parse the number
            var episodeIndex = episodeNumberSection.IndexOf("Episode");

            var episodeNumberRaw = episodeNumberSection.Substring(episodeIndex).Trim().Replace("Episode ", "");

            string episodeNumber;

            // This means its two episodes put together
            if (episodeNumberRaw.Contains("&"))
            {
                // Put them together
                var both = episodeNumberRaw.Split('&');

                episodeNumber = string.Format("e{0}-e{1}", int.Parse(both[0].Trim()).ToFriendlyName(), int.Parse(both[1].Trim()).ToFriendlyName());

            }
            else
            {
                episodeNumber = string.Format("e{0}", int.Parse(episodeNumberRaw).ToFriendlyName());
                // Put it altogether

            }

            return string.Format("s{0}{1} - {2}", seasonNumber.ToFriendlyName(), episodeNumber, episodeName);
        }

    }
}