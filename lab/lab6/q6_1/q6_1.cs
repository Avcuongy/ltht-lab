// PLACE ALL IN PROGRAM.CS
/*
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);

        // Task 2: Cấu hình chạy như Windows Service
        builder.Services.AddWindowsService(options =>
        {
            options.ServiceName = "Trading Folder Monitor Service";
        });

        // Hàm quan trọng nhất để gọi Class TradeWorker
        builder.Services.AddHostedService<TradeWorker>();

        var host = builder.Build();
        host.Run();

        Console.ReadKey();
    }
}
*/
