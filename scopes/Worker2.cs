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
            Console.Write("ServiceInjected      ");
            Console.Write($"{_singleton.Id} ");
            Console.Write($"{_scoped.Id} ");
            Console.Write($"{_transient.Id} ");
            Console.WriteLine();
        }
    }
}
