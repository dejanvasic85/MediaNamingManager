namespace MediaNamingManager
{
    /// <summary>
    /// Parses format of dexter.s05e01.hdtv.xvid-fqm.avi by finding the right text already and removing the rest
    /// </summary>
    public class StripRubbishParser : IEpisodeParser
    {
        public string RenameToEpisode(int seasonNumber, string originalFileName)
        {
            var textToFind = string.Format("s{0}", seasonNumber.ToFriendlyName());

            var indexOfSeasonNumber = originalFileName.IndexOf(textToFind);

            if (indexOfSeasonNumber == -1)
            {
                indexOfSeasonNumber = originalFileName.IndexOf(textToFind.ToUpper());
            }
            
            var episode = originalFileName.Substring(indexOfSeasonNumber, 6);

            var result = string.Format("{0}{1}", episode, originalFileName.FileExtension());
            return result;
        }
    }

}