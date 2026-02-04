using System;
using System.IO;
using System.Threading.Tasks;

public class q4_3
{
    public static object fileLock = new object();

    public static string logFile = "log.txt";

    public static void Solution()
    {
        if (File.Exists(logFile))
            File.Delete(logFile);

        Task[] tasks = new Task[5];

        for (int i = 0; i < 5; i++)
        {
            int id = i;
            tasks[i] = Task.Run(() =>
            {
                for (int j = 0; j < 10; j++)
                {
                    WriteLog($"Task {id} - message {j}");
                }
            });
        }

        Task.WaitAll(tasks);
        Console.WriteLine("Logging completed");
    }

    public static void WriteLog(string message)
    {
        lock (fileLock)
        {
            File.AppendAllText(logFile, message + Environment.NewLine);
        }
    }
}
