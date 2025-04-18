using System;

namespace EC_Simple_API.Jobs
{
    public class OrderJob : IJob
    {
        public void Execute()
        {
            Console.WriteLine("Order job is executing...");
        }
    }
}