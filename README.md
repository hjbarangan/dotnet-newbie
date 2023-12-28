## BASIC SETUP of ASP.NET CORE MVC in VSCODE.  

To create a .NET MVC application - ```dotnet new mvc -o <application-name>```

Redirect into VSCode - ```code -r <application-name>```

Run the .NET application in development mode (Hot Reload) - ```dotnet watch```

### **INSTALLATION:**

  
**Tools Used for Database Migrations and Scaffolding**

Note: --version is optional, this is only applicable to version 7.x and below.
Disregard the --version if your .NET SDK is in the latest version (8.0.0)

  
**dotnet-ef** - is a command-line tool for managing Entity Framework Core (EF Core) in .NET applications. It's used for tasks like creating and applying migrations, generating code from an existing database, and more.
  

```
dotnet tool install --global dotnet-ef --version 7.0.0 --add-source https://api.nuget.org/v3/index.json
```

  
**dotnet aspnet-codegenerator** - Runs the ASP.NET Core scaffolding engine. dotnet aspnet-codegenerator is only required to scaffold from the command line, it's not needed to use scaffolding with Visual Studio. It's used to generate repetitive code elements for ASP.NET Core applications, saving time and effort in development.

```
dotnet tool install --global  dotnet-aspnet-codegenerator --version 7.0.0 --add-source https://api.nuget.org/v3/index.json
```


**Packages**

```

dotnet add package Microsoft.EntityFrameworkCore.Design --source https://api.nuget.org/v3/index.json


dotnet add package Microsoft.EntityFrameworkCore.SQLite  --source https://api.nuget.org/v3/index.json


dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design  --source https://api.nuget.org/v3/index.json

  
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --source https://api.nuget.org/v3/index.json


dotnet add package Microsoft.EntityFrameworkCore.Tools --source https://api.nuget.org/v3/index.json

  
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --source https://api.nuget.org/v3/index.json

```

### **SCAFFOLD**

```
dotnet aspnet-codegenerator controller -name UserController -m User -dc Mvc.Data.MvcContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
```
### **DATABASE**

```
dotnet ef migrations add InitialCreate
```

This is used to add a new migration. When you're ready to persist changes to your data model (e.g., adding a new table or modifying an existing one), you create a migration to capture those changes.

`InitialCreate`: This is the name you are giving to the migration. It's a meaningful name that describes the purpose of the migration. In this case, "InitialCreate" suggests that this is the first migration in your project, often created when setting up the initial database schema.

```
dotnet ef database update
```

  
Once the migration is generated, you typically apply it to the database using the `dotnet ef database update` command. This updates the actual database schema to match the changes described in the migration.


**Here's the link of the tutorial/documentation:**

https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-8.0&tabs=visual-studio