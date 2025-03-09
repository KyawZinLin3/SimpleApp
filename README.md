# Simple App

Product CRUD feature app for code assignment.

##  Features

- **Product CRUD**: product data can create, update, view and delete. 

##  Installation

Follow these steps to set up the project locally:

```sh
git clone https://github.com/your-username/your-repo.git
cd your-repo
dotnet restore
dotnet build
```
## ⚙️ Configuration

Set up your sql server connection strings in a `appseetings.josn` file,:

```appsettings.josn
"ConnectionStrings": {
  "DefaultConnection": "localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;TrustServerCertificate=True;",
  "DatabaseConnection": "localhost\\SQLEXPRESS;Database=SimpleAppDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

##  Usage

How to run the project:

```sh
 dotnet run
```



##  Built With

- **Asp.Net Core MVC**: For building web apps using the MVC pattern.
- **Dapper**: For simple and fast data access.
- **MSSQL**: As the main database.
- **Bootstrap**: For making the site look good and work on any device.


##  Contact

For any inquiries, reach out at [kyawzinlin.dev@gmail.com](mailto:kyawzinlin.dev@gmail.com).
