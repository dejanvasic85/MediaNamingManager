namespace MediaNamingManager
{
    interface ITvRenamer
    {
        string RenameToEpisode(int seasonNumber, string originalFileName, int? index);
    }
}