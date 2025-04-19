using EC_Simple_API.Jobs;

public class DynamicJobHostedService : BackgroundService
{
    private readonly JobFactory _factory; private readonly IConfiguration _configuration;

    public DynamicJobHostedService(JobFactory factory, IConfiguration configuration)
    {
        _factory = factory;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        string jobName = _configuration["JobToRun"] ?? "OrderJob"; // 從 appsettings 或環境變數來
        var job = _factory.GetJob(jobName);

        if (job != null)
        {
            await job.ExecuteAsync(stoppingToken);
        }
    }
}