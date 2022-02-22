using Microsoft.Extensions.Logging;

namespace basic_logging
{
    public class Application
    {
        Worker _worker;
        ILogger<Application> _logger;

        
        public Application(Worker worker, ILogger<Application> logger)
        {
            _worker = worker;
            _logger = logger;
            _logger.LogInformation("Contructor called");
        }

        public void Run()
        {
            _logger.LogInformation("Run called");
            _worker.DoWork("Hello from DI");
        }
    }
}