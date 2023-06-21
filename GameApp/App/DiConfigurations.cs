using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace App
{
    //Sets settings for di
    public class DiConfigurations
    {
        public static void ConfigureServices(IServiceCollection services, Settings settings)
        {
            if (services.Any(sd => sd.ServiceType == typeof(Settings))) return; // keeps from loading multiple times

            services.AddHttpClient();
            services.AddSingleton(settings);
            //Registers all configs with di
            var assembly = typeof(DiConfigurations).GetTypeInfo().Assembly;
            services.RegisterServices(assembly, settings);
        }
    }
}
