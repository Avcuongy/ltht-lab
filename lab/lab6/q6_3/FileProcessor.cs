using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace ltht_lab.lab.lab6.q6_3 // namespace must be the same as in Program.cs to avoid confusion
{
    public class FileProcessor
    {
        private static ConcurrentDictionary<string, byte> _processingFiles = new ConcurrentDictionary<string, byte>();

        // Navigate up from bin\Debug or bin\Release to project root
        private readonly string _watchPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Data");
        private readonly string _processedPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Processed");

        public void StartMonitoring()
        {
            // Tạo thư mục nếu chưa có
            Directory.CreateDirectory(_watchPath);
            Directory.CreateDirectory(_processedPath);

            FileSystemWatcher watcher = new FileSystemWatcher(_watchPath, "*.json");
            watcher.Created += (s, e) => Task.Run(() => HandleFile(e.FullPath));
            watcher.EnableRaisingEvents = true;

            Console.WriteLine($"Watching: {_watchPath}");
            Console.WriteLine("Bỏ file JSON vào thư mục 'Data' để kiểm tra...");
        }

        private void HandleFile(string filePath)
        {
            if (!_processingFiles.TryAdd(filePath, 0)) return;

            try
            {
                System.Threading.Thread.Sleep(500); // Chờ file ghi xong

                string content = File.ReadAllText(filePath);
                Console.WriteLine($"[NEW]: {Path.GetFileName(filePath)}");

                System.Threading.Thread.Sleep(1000); // Simulate processing

                string dest = Path.Combine(_processedPath, Path.GetFileName(filePath));
                if (File.Exists(dest)) File.Delete(dest);
                File.Move(filePath, dest);

                Console.WriteLine($"[DONE]: Đã chuyển {Path.GetFileName(filePath)} vào Processed");
            }
            catch (Exception ex) { Console.WriteLine($"Lỗi: {ex.Message}"); }
            finally { _processingFiles.TryRemove(filePath, out _); }
        }
    }
}