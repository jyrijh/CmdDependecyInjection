using Microsoft.Extensions.Options;
using System;

namespace configuration_sources
{
    class Application
    {
        Configuration.Application _settings;
        Worker _worker;

        public Application(IOptions<Configuration.Application> settings, Worker worker)
        {
            _settings = settings.Value;
            _worker = worker;
        }

        public void Run()
        {
            Console.WriteLine($"StringSetting: {_settings.StringSetting}");
            Console.WriteLine($"IntSetting: {_settings.IntSetting}");
            _worker.DoWork("Worker settings");
        }
    }
}