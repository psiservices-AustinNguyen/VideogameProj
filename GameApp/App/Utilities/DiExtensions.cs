using App;
using App.Utils;
using Insight.Database;
using System.Buffers.Text;
using System.ComponentModel;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DiExtensions
    {
        //This method is responsible for registering services in the dependency injection container.
        //Assembly = Artifacts compiled into assembly used in diconfigurations
        public static void RegisterServices(this IServiceCollection services, Assembly assembly, Settings settings)
        {
            //obtaining a database connection of a specific type(T) based on a provided connection string
            var sqlServerFactory = typeof(DbAdapterFactory).GetMethod(nameof(DbAdapterFactory.GetConnectionAs));

            //Determines the type of service that is needed when setting up adapters
            foreach (var type in assembly.GetExportedTypes())
            {
                if (type.GetCustomAttribute<TransientServiceAttribute>() != null)
                {
                    services.AddTransient(type);
                }
                else if (type.GetCustomAttribute<DatabaseServiceAttribute>(true) is DatabaseServiceAttribute databaseServiceAttribute)
                {
                    services.AddTransient(type, (serviceProvider) =>
                    {

                        var connectionString = settings.DatabaseConnectionString;

                        var genericMethod = sqlServerFactory.MakeGenericMethod(type);
                        return genericMethod.Invoke(null, new object[] { connectionString });
                    });
                }
            }
        }
    }
}
