# Airport Project - DAL 📃


An ASP.NET Core 5.0 project that is the handler of all the access to the DataBase.

## Table of Contents

- [1. Motivation](#1-motivation)
- [2. Tech & frameworks used](#2-tech--frameworks-used)
- [3. Structure](#3-structure)
  - [3.1. Dummy Data](#31-dummy-data)
  - [3.2. Extensions](#32-extensions)
  - [3.3. Repositories](#33-repositories)
- [4. Installation](#4-installation)

## 1. Motivation

In order to keep things readable and simple, the project is broken down to small units [(SOC)](https://en.wikipedia.org/wiki/Separation_of_concerns).

The DAL project uses EFCore to build the Models and their relations in the DB.

In addition, the DAL project, exposes a generic repository that manages the access from other layers into the DB.

## 2. Tech & frameworks used

-   [C# 9.0](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9) and [.Net 5](https://github.com/dotnet/core/tree/master/release-notes/5.0).
-   [Entity Framework Core](https://github.com/dotnet/efcore).
-   [SQLite](https://www.sqlite.org/index.html).

## 3. Structure

The project is built of three parts:

-   [Dummy data](#31-dummy-data).
-   [Extensions](#32-extensions).
-   [Repositories](#33-repositories).
  
### 3.1. Dummy Data

Static arrays of each of the elements in the DB to be seeded for testing porpuses.

### 3.2. Extensions

Extension methods for the creation of the project's models, and handeling the connections between them.

### 3.3. Repositories

A generic repository, which can be extended with polymorphism and enables simple DI.

## 4. Installation

The DAL project is not a standalone project, and is simply the engine for the DB access.

In order to run the server you could:

1.  Go to the [releases page](https://github.com/ChemiAtlow/AirportProject/releases/latest) and download the latest Server asset for your OS.
2.  Clone the project and build the ASP.NET server project to fire-up the API server.
3.  Clone the project, and run docker compose to start a Nginx server containig the Server and the UI.
    ```bash
    docker-compose up --build
    ```
