# MultiWorld

A war simulation game palyed between Transformer groups Autobots and Decepticons to decide the winning side without actually going to war with each other.

### Before running
- Prepage Dev environment by installing : `Windows 10`,`SQL Server 2017 Developer Edition`,`Visual Studio 2017 Community Edition`,`.Net Core 2.2`
- Entity Framework Code-First creates a database named 'model-world-db' in the local SQL Server under Windows user credentials. Make sure there are not existing DB of the same name before starting the application and that the logged-in Windows user has sufficient persmissions. Otherwise switch to a different DB name/credntials by editing the connection string in `MultiWorld\appsettings.json`.

### Howto run
- Clone project from Github. This shouold create a folder named `MultiWorld`.
- From the `MultiWorld` folder, open solution file `MultiWorld.sln` in Visual Studio.
- In Visul Studio, open `Tools --> Nuget Package Manager --> Package Manager Console`.
- In `Package Manager Console` type `Update-Database` to create the app DB using EF.
- In Visul Studio, hit `F5` or `Debug--> Start Debugging` to run the program. 
- When run, the program should open a browser window with the Swagger UI for the API.

### Open source libraries used
- Swagger for API documentation
- NUnit and Moq for testing

