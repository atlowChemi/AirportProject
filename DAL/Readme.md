- [1. Airport Project - DAL](#1-airport-project---dal)
  - [1.1. Motivation](#11-motivation)
  - [1.2. Tech & frameworks used](#12-tech--frameworks-used)
  - [1.3. Structure](#13-structure)
    - [1.3.1. Dummy Data](#131-dummy-data)
    - [1.3.2. Extensions](#132-extensions)
    - [1.3.3. Repositories](#133-repositories)
  - [1.4. Installation](#14-installation)

# 1. Airport Project - DAL

An ASP.NET Core 5.0 project that is the handler of all the access to the DataBase.

## 1.1. Motivation

In order to keep things readable and simple, the project is broken down to small units [(SOC)](https://en.wikipedia.org/wiki/Separation_of_concerns).

The DAL project uses EFCore to build the Models and their relations in the DB.

In addition, the DAL project, exposes a generic repository that manages the access from other layers into the DB.

## 1.2. Tech & frameworks used

-   [C# 9.0](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9) and [.Net 5](https://github.com/dotnet/core/tree/master/release-notes/5.0).
-   [Entity Framework Core](https://github.com/dotnet/efcore).
-   [SQLite](https://www.sqlite.org/index.html).

## 1.3. Structure

The project is built of three parts:

-   [Dummy data](#131-dummy-data).
-   [Extensions](#132-extensions).
-   [Repositories](#133-repositories).
  
### 1.3.1. Dummy Data

Static arrays of each of the elements in the DB to be seeded for testing porpuses.

### 1.3.2. Extensions

Extension methods for the creation of the project's models, and handeling the connections between them.

### 1.3.3. Repositories

A generic repository, which can be extended with polymorphism and enables simple DI.

## 1.4. Installation

The DAL project is not a standalone project, and is simply the engine for the DB access.

In order to run the server you could:

1.  Go to the [releases page](https://github.com/ChemiAtlow/AirportProject/releases/latest) and download the latest Server asset for your OS.
2.  Clone the project and build the ASP.NET server project to fire-up the API server.
3.  Clone the project, and run docker compose to start a Nginx server containig the Server and the UI.
    ```bash
    docker-compose up --build
    ```
