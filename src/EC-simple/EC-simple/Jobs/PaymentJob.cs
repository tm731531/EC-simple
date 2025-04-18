using System;

namespace EC_Simple_API.Jobs
{
    public class PaymentJob : IJob
    {
        public void Execute()
        {
            Console.WriteLine("Payment job is executing...");
        }
    }
}