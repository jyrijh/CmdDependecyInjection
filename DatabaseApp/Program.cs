using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DatabaseApp
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
                    services.AddDbContext<DatabaseLibrary.DemoContext>(options =>
                        //options.UseSqlServer(hostContext.Configuration.GetConnectionString("DefaultConnection")));
                        options.UseInMemoryDatabase(hostContext.Configuration.GetConnectionString("DefaultConnection")));
                    
                    services
                        .Configure<Configuration.Application>(hostContext.Configuration.GetSection("Application"));

                    services
                        .AddSingleton<Application>();
                });
    }
}
