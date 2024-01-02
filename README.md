# Super-Simple-Scheduling-System_API

## Description

This is the first part of a two part project for the Super Simple Scheduling System challenge. For this project it was requested to create a REST API for a system that assigns students to classes. You may find the second part of the project (UI) in this repository https://github.com/RodrigoH12/Super-Simple-Scheduling-System_UI.

The Super Simple Scheduling System is a coding challenge designed to test my abilities as a full-stack developer. This specific API project was designed based on the layer architecture, OOP and design patterns, so you will find multiple projects such as Presentation, Logic and Data, that are in charge of managing data through models/objects. And also thanks to the use of design patterns, you will see that the code is organized in a clean, simple and reusable way.

## Technologies & Design Patterns Used

- .NET 8
- Entity Framework Core 8
  - Code First approach
- DB: SQL Server
- NUnit for unit testing
- Design Patterns:
  - Repository Pattern
  - Unit Of Work
  - Dependency injection

## Required CRUD

- CREATE:
  - A Student
  - A Class
  - A User

- READ:
  - List of all Students
  - List of all Classes
  - Specific User base on username and password
  - All Students assigned to a Class
  - All Classes assigned to a Student

- UPDATE:
  - A Student
  - A Class

- DELETE:
  - A Student
  - A Class
  - A User

## Project Set Up

To run the project, you can either use Visual Studio (2022 version) or the command line.

### Set Up the Database

Thanks to the fact that the project was made based on EF code first approach, we have an initial migration that when executed, automatically creates a new database `SchedulingSystemDB` within the local server used by SQL Server `(localdb)\MSSQLLocalDB`. Although the server and the name of the DB can be changed in the ConnectionStrings.DBConnection section within appsettings.Development.json file.

In order to create the database we must follow the following steps:
1. Open the `SuperSimpleSchedulingSystem.Sln` solution file in Visual Studio.
2. Select in the top menu the option Tools -> NuGet Package Manager -> Package Manager Console.
3. Set Default project to `3. Data\Data`.
4. Run the command `PM> Update-Database`.
5. The Initial migration will be applied and the database will be created with some pre-loaded data for testing.

### Running the Project

#### Visual Studio

1. Open the `SuperSimpleSchedulingSystem.Sln` solution file in Visual Studio.
2. Set the startup project to `Presentation`.
3. Press the Start button.

#### Command Line

1. Navigate to the `SuperSimpleSchedulingSystem.Sln` directory in the terminal.
2. Run the following commands:

```sh
$ dotnet restore
$ dotnet build
$ dotnet run
```

Either way, a new window will open in your browser with the following url: `https://localhost:7159/swagger/index.html` showing a swagger interface to facilitate the use of different endpoints. But when trying to connect with the API, you should use only this base url `https://localhost:7159` followed by the specific endpoint that you want to reach.