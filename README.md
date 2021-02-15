# Todo MVC
A ASP.NET Core MVC app with simple authentication created during learning MVC. Registered users can create their own ToDo lists in which tasks are stored.

## Technologies
* .NET5
* Enity Framework Core 5
* AutoMapper
* HTML
* Javascript
* Bootstrap

## Usage
### Database Configuration

The template is configured to use an in-memory database by default. This ensures that all users will be able to run the solution without needing to set up additional infrastructure (e.g. SQL Server).

If you would like to use SQL Server, you will need to update **TodoMVC/appsettings.json** as follows:

```json
  "UseInMemoryDatabase": false,
```

Verify that the **DefaultConnection** connection string within **appsettings.json** points to a valid SQL Server instance. 

When you run the application the database will be automatically created (if necessary) and the latest migrations will be applied.

## License

Distributed under the MIT License. See `LICENSE` for more information.
