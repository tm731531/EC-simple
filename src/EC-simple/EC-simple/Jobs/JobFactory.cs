using System;

namespace EC_Simple_API.Jobs
{
    public class JobFactory
    {
        public static IJob CreateJob(string jobType)
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
    }
}