# Setup Steps
```
dotnet new console -f "netcoreapp3.1" -n "ef5-core31-poc" -o .
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package System.Configuration.ConfigurationManager
dotnet add package Microsoft.Extensions.Configuration
dotnet add package Microsoft.Extensions.Configuration.Json
```

Created an empty DB in my local SQLExpress 
```
create database emppoc
```


manually configured the launch.json to the exe

installed dotnet-ef tool globally
```
dotnet tool install -g dotnet-ef
```

Added the new UserSecretsId to the csproj file to save the connection string
```
dotnet user-secrets init
```

Adding the connection string to my local secrets
```
dotnet user-secrets set ConnectionStrings.EmployeesPoc "Server=localhost\\SQLEXPRESS;Database=emppoc;Trusted_Connection=True"
```

Build the dbcontext by referencing the stored connection string
```
dotnet-ef dbcontext scaffold Name=ConnectionStrings.EmployeesPoc Microsoft.EntityFrameworkCore.SqlServer
```

# Run Steps
Run the project
```
dotnet run
```