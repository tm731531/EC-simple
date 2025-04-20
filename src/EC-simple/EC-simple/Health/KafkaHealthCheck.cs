using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace EC.simple.Health
{
    public class KafkaHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            if (JobHealthStatus.IsKafkaConnected)
            {
                return Task.FromResult(HealthCheckResult.Healthy("Kafka is connected"));
            }
            else
            {
                return Task.FromResult(HealthCheckResult.Unhealthy("Kafka is disconnected"));
            }
        }
    }
}
