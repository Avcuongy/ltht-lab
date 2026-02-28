using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

public class TradeWorker : BackgroundService
{
    private readonly ILogger<TradeWorker> _logger;

    public TradeWorker(ILogger<TradeWorker> logger)
    {
        _logger = logger;
    }

    // Task 4: Log khi Start
    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Trade Service đã bắt đầu lúc: {time}", DateTimeOffset.Now);
        await base.StartAsync(cancellationToken);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Task 3: Vòng lặp chạy mỗi 30 giây
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Đang kiểm tra folder và xử lý file giao dịch...");

            // Nghỉ 30 giây
            await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
        }
    }

    // Task 4: Log khi Stop
    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Trade Service đã dừng lúc: {time}", DateTimeOffset.Now);
        await base.StopAsync(cancellationToken);
    }
}