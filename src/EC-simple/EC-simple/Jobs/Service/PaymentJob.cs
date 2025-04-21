using System;
using EC.simple.Jobs;
using EC.simple.Main;
using EC.Utils;
namespace EC.simple.Jobs.Service
{
    public class PaymentJob : IJobWorker
    {
        private readonly ILogger<PaymentJob> _logger;
        public string JobName => "PaymentJob";

        public PaymentJob()
        {


        }
        public PaymentJob(ILogger<PaymentJob> logger)
        {
            _logger = logger;
        }
        public async Task ExecuteAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    // 假設模擬連到 Kafka，做健康檢查
                    JobHealthStatus.IsKafkaConnected = true;
                    _logger.LogInformation("db 已連線並執行支付處理。");
                    Console.WriteLine("test");
                  
                    //Console.WriteLine(MathUtils.SumData(5, 6));
                    await Task.Delay(5000, token);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "db 連線失敗");
                    JobHealthStatus.IsKafkaConnected = false;
                    await Task.Delay(5000, token);
                }
            }
        }
    }
}