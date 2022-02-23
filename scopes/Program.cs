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

            Console.WriteLine("Caller               Function             Singleton                            Scoped                               Transient");
            // worker1_one worker1_two and  will have same values unless Workers are registered as Transient
            Console.Write("Worker1 1  ");
            var worker1_one = host.Services.GetService<Worker1>();
            worker1_one.ServiceInjected();

            Console.Write("Worker1 2  ");
            var worker1_two = host.Services.GetService<Worker1>();
            worker1_two.ServiceInjected();

            Console.Write("Worker2 1  ");
            var worker2 = host.Services.GetService<Worker2>();
            worker2.ServiceInjected();

            Worker1.SerciveInFunction(host.Services);
            Worker1.SerciveInFunction(host.Services);

            Worker1.SerciveInScope(host.Services);
            Worker1.SerciveInScope(host.Services);
        }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                //services.AddSingleton<Worker1>();
                //services.AddScoped<Worker1>();
                services.AddTransient<Worker1>();
                services.AddTransient<Worker2>();
                services.AddSingleton<Singleton>();
                services.AddScoped<Scoped>();
                services.AddTransient<Transient>();
            });
}
}
