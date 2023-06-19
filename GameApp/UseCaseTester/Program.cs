using App;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace UseCaseTester
{
    class Program
    {
        static IServiceProvider _services;
        static Microsoft.Extensions.Logging.ILogger _logger;
        static async void Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();
            _services = host.Services.CreateScope().ServiceProvider;
            _logger = _services.GetRequiredService<ILogger<Program>>();

            _logger.LogInformation("starting program");

            try
            {
                //var useCase = _services.GetRequiredService<GetEvents>();
                await Task.FromResult(0);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
            }
            _logger.LogInformation("finished");
            Console.ReadKey();
        }

        static IHostBuilder CreateHostBuilder(string[] args)=>
            Host.CreateDefaultBuilder(args)
                //This means  that the program will stip when console window is closed
                .UseConsoleLifetime()
                //The program then reads the appsettings.json and configures settings based on this file
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.json");
                })
                //Add settings by creating an instance of it and adds other configurations
                .ConfigureServices((hostContext, services) =>
                {

                    var configuration = hostContext.Configuration;
                    var settings = new Settings(configuration);

                    //DiConfiguration.ConfigureServices(services, settings);
                    //services.RegisterServices(typeof(Program).GetTypeInfo().Assembly, settings);
                });

    }
}