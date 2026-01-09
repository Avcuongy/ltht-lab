using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public class lab1
{
    public static void system_info()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== CHƯƠNG TRÌNH THÔNG TIN HỆ THỐNG CHI TIẾT ===");
        Console.WriteLine("------------------------------------------------");

        // --- THÔNG TIN MÔI TRƯỜNG & HĐH ---
        Console.WriteLine("[1] MÔI TRƯỜNG HỆ ĐIỀU HÀNH");
        Console.WriteLine($"  - Hệ điều hành (OS Version): {Environment.OSVersion}");
        Console.WriteLine($"  - Nền tảng 64-bit: {Environment.Is64BitOperatingSystem}");
        Console.WriteLine($"  - Tên máy (Machine Name): {Environment.MachineName}");
        Console.WriteLine($"  - Người dùng hiện tại: {Environment.UserName}");
        Console.WriteLine($"  - Thư mục hệ thống: {Environment.SystemDirectory}");
        Console.WriteLine();

        // --- TÀI NGUYÊN PHẦN CỨNG ---
        Console.WriteLine("[2] TÀI NGUYÊN HỆ THỐNG (CPU & RAM)");
        // Số lượng bộ xử lý logic (Logical Processors)
        Console.WriteLine($"  - Số lượng vi xử lý (Processors): {Environment.ProcessorCount}");
        // Kích thước trang bộ nhớ (Page Size)
        Console.WriteLine($"  - Kích thước trang bộ nhớ (Page Size): {Environment.SystemPageSize} bytes");
        // Thời gian máy đã chạy từ lúc khởi động (Tick Count)
        Console.WriteLine($"  - Thời gian máy đã chạy (Uptime): {Environment.TickCount / 60000} phút");
        Console.WriteLine();

        // --- HỆ THỐNG TẬP TIN & I/O ---
        Console.WriteLine("[3] HỆ THỐNG LƯU TRỮ (DISK I/O)");
        Console.WriteLine($"  - Thư mục làm việc hiện tại: {Environment.CurrentDirectory}");
        Console.WriteLine("  - Danh sách các ổ đĩa logic:");

        // Lấy danh sách ổ đĩa
        DriveInfo[] drives = DriveInfo.GetDrives();
        foreach (DriveInfo drive in drives)
        {
            if (drive.IsReady)
            {
                double totalSize = drive.TotalSize / (1024.0 * 1024.0 * 1024.0);
                double freeSpace = drive.AvailableFreeSpace / (1024.0 * 1024.0 * 1024.0);

                Console.WriteLine($"    + Ổ {drive.Name} (Định dạng: {drive.DriveFormat})");
                Console.WriteLine($"      Dung lượng: {freeSpace:F2} GB trống / {totalSize:F2} GB tổng");
            }
        }

        Console.WriteLine("\n------------------------------------------------");
        Console.WriteLine("Nhấn phím bất kỳ để thoát...");
        Console.ReadKey();
    }
}
