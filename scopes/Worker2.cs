using System;

namespace scopes
{
    public class Worker2
    {
        Singleton _singleton;
        Scoped _scoped;
        Transient _transient;

        public Worker2(Singleton singleton, Scoped scoped, Transient trasient)
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
    }
}
