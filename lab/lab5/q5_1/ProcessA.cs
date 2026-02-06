using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ProcessA
{
    public static void ProcessMain()
    {
        int secret = 42;
        Console.WriteLine("Process A running...");
        Console.WriteLine($"Secret value in Process A: {secret}");
    }
}

