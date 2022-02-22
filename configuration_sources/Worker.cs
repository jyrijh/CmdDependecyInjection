using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace configuration_sources
{
    class Worker
    {
        Configuration.Worker _settings;

        public Worker(IOptions<Configuration.Worker> settings)
        {
            _settings = settings.Value;
        }

        public void DoWork(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine($"Setting1: {_settings.Setting1}");
            Console.WriteLine($"Setting2: {_settings.Setting2}");
            Console.WriteLine($"Setting3: {_settings.Setting3}");
        }
    }
}
