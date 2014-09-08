namespace MediaNamingManager
{
    interface IEpisodeParser
    {
        string RenameToEpisode(int seasonNumber, string originalFileName, int? index);
    }
}