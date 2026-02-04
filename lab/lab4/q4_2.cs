using System;
using System.Threading.Tasks;

public class q4_2
{
    public static void Solution()
    {
        {
            Task t1 = Task.Run(() =>
            {
                Task.Delay(1000).Wait();
                Console.WriteLine("Task 1 done");
            });

            Task t2 = Task.Run(() =>
            {
                Task.Delay(1500).Wait();
                Console.WriteLine("Task 2 done");
            });

            Task t3 = Task.Run(() =>
            {
                Task.Delay(2000).Wait();
                Console.WriteLine("Task 3 done");
            });

            Task.WhenAll(t1, t2, t3).Wait();

            Console.WriteLine("All tasks completed !");
        }
    }
}
