# Configuration sources

## appsettings.json
In appsettings Worker has 3 settings
```
"Worker": {
  "Setting1": "From appsetting.json",
  "Setting2": "From appsetting.json",
  "Setting3": "From appsetting.json"
}
```
## Environment variables
In environment variables the is Worker:Setting2 that has value "From environment variable"

## Commandline
From commandline we provide Worker:Setting3 with valeu "From commandline"

open project folder in command line and run following commands
```
set Worker:Setting2=From environment variable
set Worker:Setting3=From environment variable
dotnet run --Worker:Setting3="From commandline"
```

```
StringSetting: string value
IntSetting: 100
Worker settings
Setting1: From appsetting.json
Setting2: From environment variable
Setting3: From commandline
```
Setting2 has been overwritten by environment variable and Setting3 by commandline parameter.  

```
Host.CreateDefaultBuilder(args)
  .ConfigureServices((hostContext, services) =>
  {
```
hostContext hash multiple Configuration Providers and later ones values override earliers values.  
  
appsettings has lowest and commandline highest priority
- appsettings.json
- appsettings.{_Environment_}.json
- Environment variables
- Commandline parameters
  
_Environment_ comes from Environment variable DOTNET_ENVIRONMENT={Development|Staging|Production}. Production beeing default value, so you can have multiple appsettings files and have different values in these.  

**ASPNETCORE_ENVIRONMENT overrides DOTNET_ENVIRONMENT.**

