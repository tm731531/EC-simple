using System;
using EC_simple.Jobs;

namespace EC_Simple_API.Jobs
{
    public class PaymentJob : IJobWorker
    {
        public string JobName => "PaymentJob";

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            // Job еч©Х
            await Task.Delay(1000, cancellationToken);
        }
    }
}