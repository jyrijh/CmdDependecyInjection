using Microsoft.Extensions.DependencyInjection;
using System;

namespace scopes
{
    public class Worker1
    {
        Singleton _singleton;
        Scoped _scoped;
        Transient _transient;

        public Worker1(Singleton singleton, Scoped scoped, Transient trasient)
        {
            _singleton = singleton;
            _scoped = scoped;
            _transient = trasient;
        }

        internal void ServiceInjected()
        {
            Console.WriteLine("ServiceInjected");
            Console.WriteLine($"singleton: {_singleton.Id}");
            Console.WriteLine($"scoped:    {_scoped.Id}");
            Console.WriteLine($"transient: {_transient.Id}");
            Console.WriteLine();
        }

        internal static void GetSerciveInFunction(IServiceProvider services)
        {
            var singleton = services.GetService<Singleton>();
            var scoped = services.GetService<Scoped>();
            var transient = services.GetService<Transient>();

            Console.WriteLine("GetSerciveInFunction");
            Console.WriteLine($"singleton: {singleton.Id}");
            Console.WriteLine($"scoped:    {scoped.Id}");
            Console.WriteLine($"transient: {transient.Id}");
            Console.WriteLine();
        }

        internal static void GetSerciveInScope(IServiceProvider services)
        {
            using IServiceScope serviceScope = services.CreateScope();
            var provider = serviceScope.ServiceProvider;
            
            var singleton = provider.GetRequiredService<Singleton>();
            var scoped = provider.GetRequiredService<Scoped>();
            var transient = provider.GetRequiredService<Transient>();

            Console.WriteLine("GetSerciveInScope");
            Console.WriteLine($"singleton: {singleton.Id}");
            Console.WriteLine($"scoped:    {scoped.Id}");
            Console.WriteLine($"transient: {transient.Id}");
            Console.WriteLine();
        }
    }
}
