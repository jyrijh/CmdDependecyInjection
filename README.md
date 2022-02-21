# Basic structure
Dependency Injection Samples for Commandline for me learning this

## Basic application using Microsoft DI container.

Packages needed
Microsoft.Extensions.DependencyInjection 
Microsoft.Extensions.Hosting 

```var host = CreateHostBuilder(args).Build();```

Initializes the DI container

```
public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services
                        .AddSingleton<Application>();
                });
```

```.AddSingleton<Application>();``` 

This adds the Application class to DI container
Sigleton, Scoped, Transient, in this case all are same as everything will live for same lifetime as the program

```
var app = host.Services.GetService<Application>();
app.Run();
```

Gets the Application instance that DI has created and run it.


## Basic configuration
### appsettings.json
```
{
  "Application": {
    "StringSetting": "string value",
    "IntSetting":  100
  }
}
```

And in Configuration folder class Application.cs
```
class Application
{
  public string StringSetting { get; set; }
  public int IntSetting { get; set; }
}
```

```services.Configure<Configuration.Application>(hostContext.Configuration.GetSection("Application"));```

This is read by container and with ```hostContext.Configuration.GetSection("Application")``` we get named section from appsetting.json ```services.Configure<Configuration.Application>``` maps it object and adds it to container to be used by object that need it

```
Configuration.Application _settings;

public Application(IOptions<Configuration.Application> settings)
{
  _settings = settings.Value;
}
```

```public Application(IOptions<Configuration.Application> settings)``` 

DI Container automatically injects needed objects when it creates our Application object
