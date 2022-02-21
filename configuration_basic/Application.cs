using Microsoft.Extensions.Options;
using System;

namespace configuration_basic
{
    class Application
    {
        Configuration.Application _settings;

        public Application(IOptions<Configuration.Application> settings)
        {
            _settings = settings.Value;
        }

        public void Run()
        {
            Console.WriteLine("Hello from DI");
            Console.WriteLine($"StringSetting: {_settings.StringSetting}");
            Console.WriteLine($"IntSetting: {_settings.IntSetting}");
        }
    }
}
