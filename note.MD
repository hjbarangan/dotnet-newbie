ASP.NET Core is designed to be database-agnostic, meaning it can work with various relational database management systems, including PostgreSQL.

To use PostgreSQL in an ASP.NET Core MVC application, you'll typically follow these steps:

1. Install the Necessary Packages:

Install the Npgsql.EntityFrameworkCore.PostgreSQL NuGet package, which is the Entity Framework Core provider for PostgreSQL. You can do this using the Package Manager Console or the .NET CLI:

```
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

2. Configure the Database Connection:

In the appsettings.json or appsettings.Development.json file, configure the connection string for PostgreSQL. Here's an example:
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=YourDatabaseName;Username=YourUsername;Password=YourPassword"
  },
  // other configurations...
}
```

3. Configure Entity Framework in Startup.cs:

In the Startup.cs file, you need to configure Entity Framework to use PostgreSQL. Add the necessary services in the ConfigureServices method:

```
services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
```

4. Create Models:

Define your models that represent tables in your PostgreSQL database. These models will be used by Entity Framework Core to map to the database.

5. Run Migrations:

Use Entity Framework Core migrations to create the database schema based on your models. Run the following commands in the Package Manager Console or terminal:

```
dotnet ef migrations add InitialCreate
dotnet ef database update
```