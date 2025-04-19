namespace EC_simple.Main
{
    public interface IJobWorker { Task ExecuteAsync(CancellationToken cancellationToken); string JobName { get; } }
}