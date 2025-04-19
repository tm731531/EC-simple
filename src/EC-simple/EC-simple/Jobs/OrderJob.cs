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
                    // ���]�����s�� Kafka�A�����d�ˬd
                    JobHealthStatus.IsKafkaConnected = true;
                    _logger.LogInformation("Kafka �w�s�u�ð���q��B�z�C");
                    await Task.Delay(5000, token);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Kafka �s�u����");
                    JobHealthStatus.IsKafkaConnected = false;
                    await Task.Delay(5000, token);
                }
            }
        }

    }
}