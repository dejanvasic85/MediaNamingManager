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

            var namingStyle = param["style"];

            FileNameProcessor.ProcessFiles(namingStyle, directory.GetFiles().OrderBy(f => f.Name).ToArray(), seasonNumber, (originalFileName, targetFileName) =>
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(originalFileName.Name);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(targetFileName);

                originalFileName.MoveTo(Path.Combine(directory.FullName, targetFileName));
            });

            Console.ForegroundColor = ConsoleColor.White;
        }
    }

}