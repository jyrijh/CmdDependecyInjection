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

Possible scopes are Sigleton, Scoped and Transient ([see](https://github.com/jyrijh/CmdDependecyInjection/tree/master/scopes#scopes)).

```var app = host.Services.GetService<Application>();```  

Gets the Application instance that DI creates and if those classes have any dependences that they require they will also created and be injected where they are required. 

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
