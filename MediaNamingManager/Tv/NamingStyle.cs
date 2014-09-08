using Microsoft.Practices.Unity;

namespace MediaNamingManager
{
    public class NamingStyle
    {
        private static readonly IUnityContainer Container;

        static NamingStyle()
        {
            // Register all the names
            Container = new UnityContainer()
                .RegisterType<IEpisodeParser, EpisodeNameAfterDashParser>("nameafterdash")
                .RegisterType<IEpisodeParser, SimpleNumberedParser>("numbered")
                .RegisterType<IEpisodeParser, SeasonDashNumberAndNameParser>("seasondash")
                .RegisterType<IEpisodeParser, StripRubbishParser>("striprubbish")
                .RegisterType<IEpisodeParser, SeasonExEpisodeWithNameParser>("exepisode")
                .RegisterType<IEpisodeParser, EpiInNameParser>("epi")
                .RegisterType<IEpisodeParser, SimpleNumberedWithEpisodeTextParser>("episodenumbered")

                ;
        }

        private IEpisodeParser Renamer { get; set; }

        public NamingStyle(string styleName)
        {
            this.Renamer = Container.Resolve<IEpisodeParser>(styleName);
        }

        public string RenameToEpisode(int seasonNumber, string originalFileName, int? index = null)
        {
            return Renamer.RenameToEpisode(seasonNumber, originalFileName, index);
        }
    }
}