using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MediaNamingManager
{

    public class TvSeriesFileNamer
    {

        public void Rename(IDictionary<string, string> param)
        {
            var directory = new DirectoryInfo(param["dir"]);
            var seasonNumber = int.Parse(param["season"]);

            NamingStyle targetNamingStyle = new NamingStyle(param["style"]);

            for (int index = 0; index < directory.GetFiles().Length; index++)
            {
                var file = directory.GetFiles()[index];
                var targetName = targetNamingStyle.RenameToEpisode(seasonNumber, file.Name, index + 1);

                if (file.Name.Equals(targetName))
                    continue;

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(file.Name);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(targetName);
                
                file.MoveTo(Path.Combine(directory.FullName, targetName));
            }
        }
    }

}