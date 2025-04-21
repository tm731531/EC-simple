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
                    // ���]�����s�� Kafka�A�����d�ˬd
                    JobHealthStatus.IsKafkaConnected = true;
                    _logger.LogInformation("db �w�s�u�ð����I�B�z�C");
                    Console.WriteLine("test");
                  
                    //Console.WriteLine(MathUtils.SumData(5, 6));
                    await Task.Delay(5000, token);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "db �s�u����");
                    JobHealthStatus.IsKafkaConnected = false;
                    await Task.Delay(5000, token);
                }
            }
        }
    }
}