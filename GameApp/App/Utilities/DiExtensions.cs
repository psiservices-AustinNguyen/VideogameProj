using App;
using App.Utils;
using Insight.Database;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DiExtensions
    {
        //Assembly = Artifacts compiled into assembly used in diconfigurations
        public static void RegisterServices(this IServiceCollection services, Assembly assembly, Settings settings)
        {
            var sqlServerFactory = typeof(DbAdapterFactory).GetMethod(nameof(DbAdapterFactory.GetConnectionAs));

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
