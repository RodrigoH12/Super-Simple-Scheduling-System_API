# Super-Simple-Scheduling-System_API

## Description

This is the first part of a two part project for the Super Simple Scheduling System challenge. For this project it was requested to create a REST API for a system that assigns students to classes.

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

## How to Use

To run the project, you can either use Visual Studio or the command line.

### Visual Studio

1. Open the `SuperSimpleSchedulingSystem.Sln` solution file in Visual Studio.
2. Set the startup project to `Presentation`.
3. Press the Start button.

### Command Line

1. Navigate to the `SuperSimpleSchedulingSystem.Sln` directory in the terminal.
2. Run the follwoing commands:

```sh
$ dotnet restore
$ dotnet build
$ dotnet run
```
