using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public class q3_4
{
    public static void Work(object id)
    {
        Console.WriteLine($"Work {id} - Thread {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(100);
    }

    public static void Solution()
    {
        // Thread
        for (int i = 0; i < 10; i++)
        {
            var t = new Thread(Work);
            t.Start(i);
        }

        // ThreadPool
        for (int i = 0; i < 10; i++)
        {
            ThreadPool.QueueUserWorkItem(Work, i);
        }

        // Task
        for (int i = 0; i < 10; i++)
        {
            Task.Run(() => Work(i));
        }

        Console.ReadLine();
    }
}
