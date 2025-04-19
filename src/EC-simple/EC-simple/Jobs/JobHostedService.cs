using EC.simple.Jobs.Service;

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