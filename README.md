# Przykłady ze szkolenia Entity Framework Core 2.1

## Polecenia z linii polecen

* Utworzenie nowej aplikacji konsolowej

~~~ bash
dotnet new console
~~~~

* Utworzenie nowej aplikacji webapi

~~~ bash
dotnet new webapi
~~~~

* Utworzenie nowej aplikacji MVC

~~~ bash
dotnet new mvc
~~~~


* Uruchomienie aplikacji

~~~
dotnet helloworld.dll
~~~


* Uruchomienie testów jednostkowych
~~~
dotnet test
~~~

* Dodanie pakietu 
~~~ bash
dotnet add package <nazwa>
~~~

## Publikacja aplikacji

* Windows
~~~ bash
dotnet publish -c Release -r win10-x64
~~~

* Linux
~~~ bash
dotnet publish -c Release -r linux-x64
~~~

* MacOS
~~~ bash
dotnet publish -c Release -r osx-x64
~~~


## Entity Framework

* Instalacja Entity Framework

~~~ powershell
Install-Package Microsoft.EntityFrameworkCore
~~~


* Pobranie **connection string** z pliku konfiguracyjnego *appsettings.json*

~~~ json
 "ConnectionStrings": {
    "MyConnection":  "Data Source=(localdb)\\MSSQLLocalDb;Initial Catalog=MyDb;Integrated Security=true"
  }
  
  ~~~~
  
 ~~~ csharp
 string connectionString = Configuration.GetConnectionString("MyConnection");
 ~~~

* Instalacja obsługi bazy danych SQL Server
~~~ powershell
Install-Package Microsoft.EntityFrameworkCore.SqlServer
~~~

Dzięki temu możemy użyć metodę **UseSqlServer**
~~~ csharp
services.AddDbContext<MyContext>(options =>
                            options.UseSqlServer(connectionString));
~~~

* Instalacja funkcji do konfiguracji relacyjnej bazy danych, np. dodanie metody HasColumnType
~~~ powershell
Install-Package Microsoft.EntityFrameworkCore.Relational
~~~

Przykład:
~~~ csharp
builder
              .Property(p => p.UnitPrice)
              .HasColumnType("decimal(10,2)");
			  
~~~

## Migracje

1. Instalacja narzędzi do Visual Studio 

* PMC
~~~ Powershell
PM> Install-Package Microsoft.EntityFrameworkCore.Tools
~~~

* CLI
~~~ bash
dotnet add package Microsoft.EntityFrameworkCore.Tools.DotNet
~~~


### Utworzenie bazy danych

PMC
~~~ Powershell
Add-Migration InitialCreate
~~~

CLI
~~~ bash
dotnet ef migrations add InitialCreate
~~~

### Zastosowanie migracji do utworzenie bazy danych

PMC
~~~ Powershell
Update-Database
~~~

CLI
~~~ bash
dotnet ef database update
~~~


### Dodanie migracji

PMC
~~~ Powershell
Add-Migration AddCustomerCity
~~~

CLI
~~~ bash
dotnet ef migrations add AddCustomerCity
~~~


4. Zastosuj migrację

~~~ Powershell
Update-Database
~~~

### Usuwanie migracji

PMC
~~~ Powershell
Remove-Migration
~~~

CLI
~~~ bash
dotnet ef migrations remove
~~~


### Powracanie do migracji

PMC
~~~ Powershell
Update-Database LastGoodMigration
~~~

CLI
~~~ bash
dotnet ef database update LastGoodMigration
~~~



### Generowanie skryptu SQL
PMC
~~~ Powershell
Script-Migration
~~~

CLI
~~~ bash
dotnet ef migrations script
~~~
