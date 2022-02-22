using Microsoft.Extensions.Logging;
using System;

namespace basic_logging
{
    public class Worker
    {
        ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            _logger.LogInformation("Constructor called");
        }

        public void DoWork(string message)
        {
            _logger.LogInformation("DoWork called with {message}", message);
        }
    }
}