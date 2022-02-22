# Basic samples for using DI
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
        .AddSingleton<Application>()
        .AddSingleton<Worker>();
    });
```

```.AddSingleton<Application>();``` 

This registers the Application class to DI container, and container will instatiate object when it is needed, and it will also remove it.
If you add it by creating it yourself like this ```.AddSingleton(new Application);``` then you need to remove it also yourself

Sigleton, Scoped, Transient, in this case all are same as everything will live for same lifetime as the program.
If you need to use Factory method that creates objects that have been registered to container. Then you can use correct lifetime scopes for those classes.
Also in ASP.NET Core API services you need to take care to use proper lifetime.

```var app = host.Services.GetService<Application>();```  

Gets the Application instance that DI has created and if those classes have any dependences that they require they will be inject also into those objects. 

```
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
```

If you forget to register the service then this will return null.  
You can use ```host.Services.GetRequiredService<Application>();``` which will throw InvalidOperationException if the service isn't found.  
  
  
   
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

Add Configuration folder and in there class Application.cs.  
I use same class name for configuration classes as the class that uses it but they are in namespace _Application_.Configuration.  
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
