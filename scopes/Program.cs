using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace scopes
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            // worker1_one worker1_two and  will have same values unless Worker1 is registered as Transient
            Console.WriteLine("Worker1 instance 1");
            var worker1_one = host.Services.GetService<Worker1>();
            worker1_one.ServiceInjected();

            Console.WriteLine("Worker1 instance 2");
            var worker1_two = host.Services.GetService<Worker1>();
            worker1_two.ServiceInjected();

            Console.WriteLine("Worker2 instance 1");
            var worker2 = host.Services.GetService<Worker2>();
            worker2.ServiceInjected();

            Worker1.GetSerciveInFunction(host.Services);
            Worker1.GetSerciveInFunction(host.Services);

            Worker1.GetSerciveInScope(host.Services);
            Worker1.GetSerciveInScope(host.Services);
        }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                //services.AddSingleton<App>();
                //services.AddScoped<App>();
                services.AddTransient<Worker1>();
                services.AddTransient<Worker2>();
                services.AddSingleton<Singleton>();
                services.AddScoped<Scoped>();
                services.AddTransient<Transient>();
            });
}
}
