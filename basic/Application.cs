using System;

namespace basic
{
    class Application
    {
        Worker _worker;

        public Application(Worker worker)
        {
            _worker = worker;
        }

        public void Run()
        {
            _worker.DoWork("Hello from DI");
        }
    }
}
