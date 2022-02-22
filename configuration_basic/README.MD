# Basic configuration

## appsettings.json
```
{
  "Application": {
    "StringSetting": "string value",
    "IntSetting":  100
  }
}
```

## Class to hold configuration values
Add Configuration folder and in there class Application.cs.  
I use same class name for configuration classes as the class that uses it but they are in namespace _Application_.Configuration.  
```
class Application
{
  public string StringSetting { get; set; }
  public int IntSetting { get; set; }
}
```
  
## Getting the values from appsettings to objects

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
