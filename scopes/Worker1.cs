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
            Console.Write("ServiceInjected      ");
            Console.Write($"{_singleton.Id} ");
            Console.Write($"{_scoped.Id} ");
            Console.Write($"{_transient.Id} ");
            Console.WriteLine();
        }

        internal static void SerciveInFunction(IServiceProvider services)
        {
            var singleton = services.GetService<Singleton>();
            var scoped = services.GetService<Scoped>();
            var transient = services.GetService<Transient>();

            Console.Write("Static     ");
            Console.Write("GetSerciveInFunction ");
            Console.Write($"{singleton.Id} ");
            Console.Write($"{scoped.Id} ");
            Console.Write($"{transient.Id} ");
            Console.WriteLine();
        }

        internal static void SerciveInScope(IServiceProvider services)
        {
            using IServiceScope serviceScope = services.CreateScope();
            var provider = serviceScope.ServiceProvider;
            
            var singleton = provider.GetRequiredService<Singleton>();
            var scoped = provider.GetRequiredService<Scoped>();
            var transient = provider.GetRequiredService<Transient>();

            Console.Write("Static     ");
            Console.Write("GetSerciveInScope    ");
            Console.Write($"{singleton.Id} ");
            Console.Write($"{scoped.Id} ");
            Console.Write($"{transient.Id} ");
            Console.WriteLine();
        }
    }
}
