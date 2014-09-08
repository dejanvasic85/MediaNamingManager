using Microsoft.Practices.Unity;

namespace MediaNamingManager
{
    public class NamingStyle
    {
        private static readonly IUnityContainer Container;

        static NamingStyle()
        {
            // Register all the names
            Container = new UnityContainer();
            Container.RegisterType<IEpisodeParser, EpisodeNameAfterDashParser>("nameafterdash");
            Container.RegisterType<IEpisodeParser, SimpleNumberedParser>("numbered");
            Container.RegisterType<IEpisodeParser, SeasonDashNumberAndNameParser>("seasondash");
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