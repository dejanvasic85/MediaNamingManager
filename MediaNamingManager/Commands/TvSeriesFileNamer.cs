using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MediaNamingManager
{

    public class TvEpisodeFileNamer
    {

        public void Rename(IDictionary<string, string> param)
        {
            var directory = new DirectoryInfo(param["dir"]);
            if (!directory.Exists)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The directory does not exist");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            var seasonNumber = int.Parse(param["season"]);

            var targetNamingStyle = new NamingStyle(param["style"]);

            var files = directory.GetFiles();

            foreach (var file in files)
            {
                var targetName = targetNamingStyle.RenameToEpisode(seasonNumber, file.Name);

                if (file.Name.Equals(targetName))
                    continue;

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(file.Name);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(targetName);
                
                file.MoveTo(Path.Combine(directory.FullName, targetName));
            }
                
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

}