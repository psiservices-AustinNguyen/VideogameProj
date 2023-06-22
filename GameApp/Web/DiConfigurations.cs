using App;
using System.Reflection;

namespace Web
{
    public static class DiConfigurations
    {
        //configures the services from app onto the web as well
        public static void ConfigureServices(IServiceCollection services, Settings settings)
        {
            App.DiConfigurations.ConfigureServices(services, settings);

            services.AddSingleton(settings);

            var assembly = typeof(DiConfigurations).GetTypeInfo().Assembly;
            services.RegisterServices(assembly, settings);
        }
    }
}