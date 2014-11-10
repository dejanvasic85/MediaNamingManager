using System;
using System.IO;
using System.Linq;
using Microsoft.Practices.Unity;

namespace MediaNamingManager
{
    public class FileNameProcessor
    {
        private static readonly IUnityContainer Container;

        static FileNameProcessor()
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
                .RegisterType<IEpisodeParser, EpisodeInNameParser>("episodeInName")
                ;
        }

        public static bool CanProcess(string namingStyle)
        {
            return Container.IsRegistered(typeof(IEpisodeParser), namingStyle);
        }

        public static void ProcessFiles(string namingStyle, FileInfo[] files, int seasonNumber, Action<FileInfo, string> fileCompleted)
        {
            var renamer = Container.IsRegistered<IEpisodeParser>(namingStyle) ? Container.Resolve<IEpisodeParser>(namingStyle) : null;

            for (int index = 0; index < files.Length; index++)
            {
                var file = files[index];
                
                var targetName = renamer != null 
                    ? renamer.RenameToEpisode(seasonNumber, file.Name) 
                    : string.Format("S{0}E{1}{2}", seasonNumber.ToFriendlyName(), (index + 1).ToFriendlyName(), file.Name.FileExtension());

                if (file.Name.Equals(targetName))
                {
                    continue;
                }

                fileCompleted(file, targetName);
            }
        }
    }
}