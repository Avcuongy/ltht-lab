using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


struct PointStruct
{
    public int X;
    public int Y;
}

class PointClass
{
    public int X;
    public int Y;
}

public class q1
{
    public static void Solution()
    {
        // value type
        PointStruct ps1 = new PointStruct { X = 1, Y = 2 };
        PointStruct ps2 = ps1;
        ps2.X = 10;

        Console.WriteLine("Struct:");
        Console.WriteLine($"ps1.X = {ps1.X}, ps1.Y = {ps1.Y}");
        Console.WriteLine($"ps2.X = {ps2.X}, ps2.Y = {ps2.Y}");

        // reference type
        PointClass pc1 = new PointClass { X = 1, Y = 2 };
        PointClass pc2 = pc1;
        pc2.X = 10;

        Console.WriteLine("\nClass:");
        Console.WriteLine($"pc1.X = {pc1.X}, pc1.Y = {pc1.Y}");
        Console.WriteLine($"pc2.X = {pc2.X}, pc2.Y = {pc2.Y}");
    }
}