using App;
using App.Utils;
using Insight.Database;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DiExtensions
    {
        //This method is responsible for registering services in the dependency injection container.
        //Assembly = Artifacts compiled into assembly used in diconfigurations?
        //Artifacts needed to build application?
        public static void RegisterServices(this IServiceCollection services, Assembly assembly, Settings settings)
        {
            //obtaining a database connection of a specific type(T) based on a provided connection string from DbAdapterFactory
            var sqlServerFactory = typeof(DbAdapterFactory).GetMethod(nameof(DbAdapterFactory.GetConnectionAs));

            //Determines the type of service that is needed when setting up adapters
            foreach (var type in assembly.GetExportedTypes())
            {
                //For the useCases
                if (type.GetCustomAttribute<TransientServiceAttribute>() != null)
                {
                    services.AddTransient(type);
                }
                //Makes the connection string into a generic type?
                //For the ConnectionString.cs
                else if (type.GetCustomAttribute<DatabaseServiceAttribute>(true) is DatabaseServiceAttribute databaseServiceAttribute)
                {
                    services.AddTransient(type, (serviceProvider) =>
                    {
                        //Get connection string from Settings.cs
                        var connectionString = settings.DatabaseConnectionString;

                        //Using reflection to make and return a generic type that was setup in DbAdapterFactory
                        var genericMethod = sqlServerFactory.MakeGenericMethod(type);
                        return genericMethod.Invoke(null, new object[] { connectionString });
                    });
                }
            }
        }
    }
}
