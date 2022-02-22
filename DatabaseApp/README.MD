# DatabaseApp  
  
This uses DatabaseLibrary which is simple Database with one table.
This version uses In memory database for simplicity, using actual doesn't change the program much, library need more changes.

```
services.AddDbContext<DatabaseLibrary.DemoContext>(options =>
  options.UseInMemoryDatabase(hostContext.Configuration.GetConnectionString("DefaultConnection")));
```

AddDbContext Injects the database context to DI container and options.UseInMemoryDatabase configures it. 
For memory database this doesn't do anything in this case, but for actual database it would pull the connectionString from appsettings.json
```
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=TestDB;Trusted_Connection=True;"
}
```

If you want to use actual database then uncomment lines in democontext.cs and change DatabaseLibrary Packages  
Remove  
Microsoft.EntityFrameworkCore.InMemory  
Add  
Microsoft.EntityFrameworkCore.Design -> needed for DesignTimeDbContextFactory  
Microsoft.EntityFrameworkCore.SqlServer  

run 
```
dotnet ef migrations add Initial
dotnet ef database update
``` 
