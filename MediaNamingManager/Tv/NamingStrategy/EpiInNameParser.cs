namespace MediaNamingManager
{
    /// <summary>
    /// Parses format of Modern Family S01 Epi01 Pilot.avi
    /// </summary>
    public class EpiInNameParser : IEpisodeParser
    {
        public string RenameToEpisode(int seasonNumber, string originalFileName, int? index = null)
        {
            var seasonInNameIndex = originalFileName.IndexOf(seasonNumber.ToFriendlyName() + " Epi", System.StringComparison.Ordinal);

            var episodeNumber = originalFileName.Substring(seasonInNameIndex + 6, 2);

            var episodeNameWithExtension = originalFileName.Substring(seasonInNameIndex + 9);

            var full = string.Format("s{0}e{1} - {2}", seasonNumber.ToFriendlyName(), episodeNumber, episodeNameWithExtension);
            return full;
        }
    }
}