using Microsoft.Win32;
using System;

public class RegistryHelper
{
    public static void ReadConfiguration()
    {
        string registryPath = @"SOFTWARE\TradingService";

        try
        {
            // 1. Mở Registry Key (HKEY_LOCAL_MACHINE)
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryPath))
            {
                // 2. Kiểm tra nếu Key không tồn tại
                if (key == null)
                {
                    Console.WriteLine($"[Error Logging]: Registry key {registryPath} không tồn tại.");
                    return;
                }

                // 3. Đọc các giá trị
                var inputFolder = key.GetValue("InputFolder");
                var processedFolder = key.GetValue("ProcessedFolder");
                var intervalSeconds = key.GetValue("IntervalSeconds");

                // 4. Kiểm tra logic (Configuration invalid)
                if (inputFolder == null || processedFolder == null || intervalSeconds == null)
                {
                    Console.WriteLine("[Error Logging]: Một hoặc nhiều giá trị cấu hình bị thiếu.");
                }
                else
                {
                    Console.WriteLine("--- Cấu hình từ Registry ---");
                    Console.WriteLine($"Input: {inputFolder}");
                    Console.WriteLine($"Processed: {processedFolder}");
                    Console.WriteLine($"Interval: {intervalSeconds}s");
                }
            }
        }
        catch (Exception ex)
        {
            // 5. Handle lỗi runtime chung
            Console.WriteLine($"[Error Logging]: Có lỗi xảy ra: {ex.Message}");
        }
    }
}