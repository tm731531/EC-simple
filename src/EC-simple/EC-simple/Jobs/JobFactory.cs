using System;
using EC_simple.Jobs;
using static System.Reflection.Metadata.BlobBuilder;

namespace EC_Simple_API.Jobs
{
    public class JobFactory
    {
        public static IJobWorker CreateJob(string jobType)
        {
            switch (jobType)
            {
                case "OrderJob":
                    return new OrderJob();
                case "PaymentJob":
                    return new PaymentJob();
                default:
                    throw new ArgumentException("Invalid job type.");
            }
        }
        private readonly IEnumerable<IJobWorker> _jobs;
        public JobFactory(IEnumerable<IJobWorker> jobs)
        {
            _jobs = jobs;
        }

        public IJobWorker? GetJob(string jobName)
        {
            return _jobs.FirstOrDefault(j => j.JobName.Equals(jobName, StringComparison.OrdinalIgnoreCase));
        }
    }
    }