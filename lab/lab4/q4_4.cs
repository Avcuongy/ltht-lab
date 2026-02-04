using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

public class q4_4
{
    public static void Solution()
    {
        string folder = "input";
        Directory.CreateDirectory(folder);

        FileSystemWatcher watcher = new FileSystemWatcher(folder);
        watcher.Created += OnFileCreated;
        watcher.EnableRaisingEvents = true;

        Console.WriteLine("Monitoring folder... Press Enter to exit.");
        Console.ReadLine();
    }

    public static void OnFileCreated(object sender, FileSystemEventArgs e)
    {
        Task.Run(() =>
        {
            try
            {
                // wait until file is fully written
                Task.Delay(500).Wait();

                byte[] data = File.ReadAllBytes(e.FullPath);
                string output = e.FullPath + ".gz";

                using (FileStream fs = new FileStream(output, FileMode.Create))
                {
                    using (GZipStream gzip = new GZipStream(fs, CompressionMode.Compress))
                    {
                        gzip.Write(data, 0, data.Length);
                    }
                }

                Console.WriteLine($"Compressed: {e.Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        });
    }
}
