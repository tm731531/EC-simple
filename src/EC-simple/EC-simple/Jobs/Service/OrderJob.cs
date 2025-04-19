using System;
using EC.simple.Jobs;
using EC.simple.Main;
using Microsoft.Extensions.Logging;

namespace EC.simple.Jobs.Service
{
    public class OrderJob : IJobWorker
    {
        private readonly ILogger<OrderJob> _logger;

        public string JobName => "OrderJob";

        public OrderJob()
        {
            

        }
        public OrderJob(ILogger<OrderJob> logger)
        {
            _logger = logger;
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