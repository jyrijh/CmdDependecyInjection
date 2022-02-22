using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace configuration_sources
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var app = host.Services.GetService<Application>();
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services
                        .Configure<Configuration.Worker>(hostContext.Configuration.GetSection("Worker"))
                        .Configure<Configuration.Application>(hostContext.Configuration.GetSection("Application"));

                    services
                        .AddSingleton<Worker>()
                        .AddSingleton<Application>();
                });
    }
}
