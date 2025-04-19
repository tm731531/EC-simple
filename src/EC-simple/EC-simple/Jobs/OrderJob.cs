using System;
using EC_simple.Jobs;
using EC_simple.Main;

namespace EC_Simple_API.Jobs
{
    public class OrderJob : IJobWorker
    {
        private readonly ILogger<OrderJob> _logger;

        public string JobName => "OrderJob";

        public void Execute()
        {
            Console.WriteLine("Order job is executing...");
        }
        public OrderJob(ILogger<OrderJob> logger)
        {
            _logger = logger;
        }
        public OrderJob()
        {
           
        }

        public async Task ExecuteAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    // 假設模擬連到 Kafka，做健康檢查
                    JobHealthStatus.IsKafkaConnected = true;
                    _logger.LogInformation("Kafka 已連線並執行訂單處理。");
                    await Task.Delay(5000, token);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Kafka 連線失敗");
                    JobHealthStatus.IsKafkaConnected = false;
                    await Task.Delay(5000, token);
                }
            }
        }

    }
}