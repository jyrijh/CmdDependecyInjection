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
