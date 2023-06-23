//This line imports the necessary namespace to access the IServiceCollection interface and related classes for configuring dependency injection
using Microsoft.Extensions.DependencyInjection;

//This line imports the necessary namespace to work with reflection, which allows you to dynamically inspect and manipulate types and assemblies
using System.Reflection;

namespace App
{
    //Sets settings for di 
    //DI CONFIG IS WHERE DEPENDENCY IS INJECTED
    public class DiConfigurations
    {
        public static void ConfigureServices(IServiceCollection services, Settings settings)
        {
            //checks if the IServiceCollection already contains a service registration for the Settings type.
            //If it does, the method returns immediately to avoid registering the services multiple times
            if (services.Any(sd => sd.ServiceType == typeof(Settings))) return; // keeps from loading multiple times

            //adds an HTTP client service to the IServiceCollection. This is useful if you need to make HTTP requests from your application
            services.AddHttpClient();

            //registers the Settings object as a singleton service in the IServiceCollection.
            //This means that the same instance of Settings will be used throughout the application.
            services.AddSingleton(settings);

            //Registers all configs with dependency injection
            //retrieves the assembly where the DiConfigurations class is defined.
            //It uses reflection to get the assembly containing this class
            var assembly = typeof(DiConfigurations).GetTypeInfo().Assembly;

            //This line calls the RegisterServices extension method on the IServiceCollection object to
            //register the services from the specified assembly(assembly).It also passes
            //the settings object to be used within the service registrations
            services.RegisterServices(assembly, settings);
        }
    }
}
