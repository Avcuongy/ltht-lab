using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class lab1
{
    public static void Solution()
    {
        Console.OutputEncoding = Encoding.UTF8;

        int col1 = 35;
        int col2 = 55;

        void Line()
        {
            Console.WriteLine("+" + new string('-', col1) + "+" + new string('-', col2) + "+");
        }

        void Row(string left, string right)
        {
            Console.WriteLine("|" + left.PadRight(col1) + "|" + right.PadRight(col2) + "|"
            );
        }

        // MÔI TRƯỜNG HỆ ĐIỀU HÀNH
        Line();
        Row("MÔI TRƯỜNG HỆ ĐIỀU HÀNH", "");
        Line();
        Row("Hệ điều hành", Environment.OSVersion.ToString());
        Row("Nền tảng 64-bit", Environment.Is64BitOperatingSystem.ToString());
        Row("Tên máy", Environment.MachineName);
        Row("Người dùng hiện tại", Environment.UserName);
        Row("Thư mục hệ thống", Environment.SystemDirectory);
        Line();

        // CPU & RAM
        Row("TÀI NGUYÊN HỆ THỐNG", "");
        Line();
        Row("Số vi xử lý logic", Environment.ProcessorCount.ToString());
        Row("Kích thước trang bộ nhớ", $"{Environment.SystemPageSize} bytes");
        Row("Thời gian chạy (Uptime)",
            $"{Environment.TickCount / 60000} phút");
        Line();

        // DISK
        Row("HỆ THỐNG LƯU TRỮ", "");
        Line();

        DriveInfo[] drives = DriveInfo.GetDrives();
        foreach (DriveInfo drive in drives)
        {
            if (!drive.IsReady) continue;

            double total = drive.TotalSize / (1024.0 * 1024 * 1024);
            double free = drive.AvailableFreeSpace / (1024.0 * 1024 * 1024);

            Row($"Ổ đĩa {drive.Name}",
                $"{free:F2} GB trống / {total:F2} GB ({drive.DriveFormat})");
        }

        Line();
    }
}
