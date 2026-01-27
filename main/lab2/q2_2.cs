using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

struct DataStruct
{
    public int A;
    public int B;
    public int C;
}

class DataClass
{
    public int A;
    public int B;
    public int C;
}

public class q2_2
{
    const int SIZE = 5_000_000;

    public static void Solution()
    {
        Console.WriteLine("=== STRUCT ARRAY TEST ===");
        TestStructArray();

        Console.WriteLine("\n=== CLASS ARRAY TEST ===");
        TestClassArray();
    }

    public static void TestStructArray()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        long memBefore = GC.GetTotalMemory(true);

        DataStruct[] arr = new DataStruct[SIZE];
        for (int i = 0; i < SIZE; i++)
        {
            arr[i].A = i;
            arr[i].B = i + 1;
            arr[i].C = i + 2;
        }

        long memAfter = GC.GetTotalMemory(true);
        Console.WriteLine($"Memory used (struct): {(memAfter - memBefore) / 1024 / 1024} MB");

        Stopwatch sw = Stopwatch.StartNew();
        long sum = 0;
        for (int i = 0; i < SIZE; i++)
        {
            sum += arr[i].A;
        }
        sw.Stop();

        Console.WriteLine($"Access time (struct): {sw.ElapsedMilliseconds} ms");
        Console.WriteLine($"Checksum: {sum}");
    }

    public static void TestClassArray()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        long memBefore = GC.GetTotalMemory(true);

        DataClass[] arr = new DataClass[SIZE];
        for (int i = 0; i < SIZE; i++)
        {
            arr[i] = new DataClass
            {
                A = i,
                B = i + 1,
                C = i + 2
            };
        }

        long memAfter = GC.GetTotalMemory(true);
        Console.WriteLine($"Memory used (class): {(memAfter - memBefore) / 1024 / 1024} MB");

        Stopwatch sw = Stopwatch.StartNew();
        long sum = 0;
        for (int i = 0; i < SIZE; i++)
        {
            sum += arr[i].A;
        }
        sw.Stop();

        Console.WriteLine($"Access time (class): {sw.ElapsedMilliseconds} ms");
        Console.WriteLine($"Checksum: {sum}");
    }
}
