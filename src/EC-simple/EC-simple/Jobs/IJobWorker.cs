namespace EC_simple.Jobs
{
    public interface IJobWorker { Task ExecuteAsync(CancellationToken cancellationToken); string JobName { get; } }
}