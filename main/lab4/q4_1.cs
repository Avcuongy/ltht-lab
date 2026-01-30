using System;
using System.Threading;
using System.Threading.Tasks;

public class q4_1
{
    internal static int counter = 0;
    internal static object locker = new object();

    internal static void Solution()
    {
        Task[] tasks = new Task[5];

        // Race Condition
        counter = 0;
        for (int i = 0; i < 5; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                for (int j = 0; j < 100000; j++)
                    counter++;   // NOT thread-safe
            });
        }

        Task.WaitAll(tasks);
        Console.WriteLine("Race condition result: " + counter);

        // Fix with lock
        counter = 0;
        for (int i = 0; i < 5; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                for (int j = 0; j < 100000; j++)
                {
                    lock (locker)
                    {
                        counter++;
                    }
                }
            });
        }

        Task.WaitAll(tasks);
        Console.WriteLine("Using lock: " + counter);

        // Fix with Interlocked
        counter = 0;
        for (int i = 0; i < 5; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                for (int j = 0; j < 100000; j++)
                    Interlocked.Increment(ref counter);
            });
        }

        Task.WaitAll(tasks);
        Console.WriteLine("Using Interlocked: " + counter);
    }
}
