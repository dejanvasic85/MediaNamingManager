using System.Collections.Generic;

namespace MediaNamingManager
{
    class Program
    {
        static void Main(string[] args)
        {
            TvSeriesFileNamer namer = new TvSeriesFileNamer();

            namer.Rename(new Dictionary<string, string>
            {
                {"dir", args[0]},
                {"season", args[1]},
                {"style", args[2]}
            }
            );
        }
    }
}
