using System;
using Confluent.Kafka;
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
                    // 假設模擬連到 Kafka，做健康檢查
                    JobHealthStatus.IsKafkaConnected = true;
                    _logger.LogInformation("Kafka 已連線並執行訂單處理。");

                    var consumerConfig = new ConsumerConfig
                    {
                        BootstrapServers = "localhost:19092",
                        GroupId = "test-consumer-group",
                        AutoOffsetReset = AutoOffsetReset.Earliest,
                        EnableAutoCommit = false
                        //,
                        //Debug = "all"



                    };

                    using var consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();

                    consumer.Subscribe("test.topic");

                    CancellationTokenSource cts = new CancellationTokenSource();
                    Console.CancelKeyPress += (_, e) =>
                    {
                        e.Cancel = true; cts.Cancel();
                    };

                    var config = new ProducerConfig
                    {
                        BootstrapServers = "localhost:19092,localhost:19094,localhost:19096",
                        SecurityProtocol = SecurityProtocol.Plaintext
                        //SecurityProtocol = SecurityProtocol.Plaintext
                        //BootstrapServers = "localhost:19092,localhost:19096,localhost:19094",
                        //SecurityProtocol = SecurityProtocol.Plaintext
                    };
                    using var producer = new ProducerBuilder<Null, string>(config).Build();

                    try
                    {
                        var dr = producer.ProduceAsync("test.topic", new Message<Null, string> { Value = "Hello Kafka from .NET!22" }).Result;
                        Console.WriteLine($"Delivered to: {dr.TopicPartitionOffset}");
                    }
                    catch (ProduceException<Null, string> e)
                    {
                        Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                    }

                    try
                    {
                        while (true)
                        {
                            Console.WriteLine("data");
                            //var cr = consumer.Consume(cts.Token);
                            var cr = consumer.Consume(TimeSpan.FromSeconds(5));  // 設置超時
                            if (cr != null)
                            {
                                Console.WriteLine($"Consumed message '{cr.Value}' at: {cr.TopicPartitionOffset}");
                                consumer.Commit(cr);
                            }
                            else
                            {
                                Console.WriteLine("No message received in the timeout.");
                            }
                            //Console.WriteLine($"Consumed message '{cr.Value}' at: {cr.TopicPartitionOffset}");
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        consumer.Close();
                    }
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