using System;
using System.IO;

namespace MediaWatcher
{
    class Program
    {
        private string Path { get; set; }
        private string Destination { get; set; }

        public Program()
        { }

        public Program(string path, string destination)
        {
            Path = path;
            Destination = destination;
        }

        static void Main(string[] args)
        {
            var program = new Program(args[0], args[1]);
            program.Watch();
            Console.ReadLine();
        }

        private void Watch()
        {
            if (!Directory.Exists(Path))
            {
                Console.WriteLine("Directory does not exist");
                return;
            }

            if (!Directory.Exists(Destination))
            {
                Directory.CreateDirectory(Destination);
            }

            Console.WriteLine("Starting watcher on " + Path);

            var watcher = new FileSystemWatcher();
            watcher.Changed += OnChanged;
            watcher.Filter = "*.*";
            watcher.Path = Path;
            watcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.FileName | NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.Size | NotifyFilters.Security;
            watcher.InternalBufferSize = 64;
            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (Directory.Exists(e.FullPath))
            {
                // This is the trigger for a folder once the files are completed copying
                Console.WriteLine("Copying {0} To: {1}", e.FullPath, Destination);
                string[] files = Directory.GetFiles(e.FullPath, "*.*", SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    try
                    {
                        Console.WriteLine("Copying {0}");
                        File.Copy(file, file.Replace(e.FullPath, Destination));
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
