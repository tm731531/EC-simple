using System.Reflection;

namespace EC_simple.Main
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterAllJobWorkers(this IServiceCollection services, Assembly assembly)
        {
            var jobTypes = assembly.GetTypes().Where(t => typeof(IJobWorker).IsAssignableFrom(t) && t is { IsAbstract: false, IsInterface: false });
            foreach (var type in jobTypes)
            {
                services.AddSingleton(typeof(IJobWorker), type);
            }

           
        }
    }
}
