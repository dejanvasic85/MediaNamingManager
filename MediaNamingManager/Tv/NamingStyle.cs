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
            Container.RegisterType<ITvRenamer, EpisodeNameAfterDashRenamer>("EpisodeAfterDash");
            Container.RegisterType<ITvRenamer, SimpleIndexedRenamer>("simple");
        }

        private ITvRenamer Renamer { get; set; }

        public NamingStyle(string styleName)
        {
            this.Renamer = Container.Resolve<ITvRenamer>(styleName);
        }

        public string RenameToEpisode(int seasonNumber, string originalFileName, int? index = null)
        {
            return Renamer.RenameToEpisode(seasonNumber, originalFileName, index);
        }
    }
}