using EC_Simple_API.Jobs;

public class JobHostedService : BackgroundService
{
    private readonly OrderJob _job;
    public JobHostedService(OrderJob job)
    {
        _job = job;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _job.ExecuteAsync(stoppingToken);
    }
}