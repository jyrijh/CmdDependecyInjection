# Logging

.NET provides logging capabilities out of the box when your application calls ```CreateDefaultBuilder``` (see [Logging in .NET](https://docs.microsoft.com/en-us/dotnet/core/extensions/logging?tabs=command-line)).  
It has these buildin providers [Logging Providers in .NET](https://docs.microsoft.com/en-us/dotnet/core/extensions/logging-providers).  

- Console  
Outputs to console
- Debug  
Writes to TraceListener using Debug.WriteLine method, see [Debug.WriteLine](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.debug.writeline?view=net-6.0) and [DefaultTraceListener](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.defaulttracelistener?view=net-6.0).
- EventSource, see [ETW](https://docs.microsoft.com/en-us/windows/win32/etw/event-tracing-portal).
- EventLog (Windows only)
- Azure App Service

You can use additional [third party providers](https://docs.microsoft.com/en-us/dotnet/core/extensions/logging-providers#third-party-logging-providers) to enchace logging.  

To use logging add ```using Microsoft.Extensions.Logging;``` and ```ILogger<class>``` dependecy to you class.  
```<class>``` in this is Log category, this can be arbitrary but convention is to use class name. This is used in logmessages ```basic_logging.Worker[0] Constructor called``` to provide catogory for the message.

```
using Microsoft.Extensions.Logging;

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
```
This will produce following output
```
info: basic_logging.Worker[0]
      Constructor called
info: basic_logging.Application[0]
      Contructor called
info: basic_logging.Application[0]
      Run called
info: basic_logging.Worker[0]
      DoWork called with Hello from DI
```

## Configure logging
You can configure logging using appsettins.json or in code. Appsettings is preferred way to do this
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```
