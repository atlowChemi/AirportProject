- [1. Airport Project - Common](#1-airport-project---common)
  - [1.1. Motivation](#11-motivation)
  - [1.2. Tech & frameworks used](#12-tech--frameworks-used)
  - [1.3. Structure](#13-structure)
    - [1.3.1. Constants](#131-constants)
    - [1.3.2. Data](#132-data)
    - [1.3.3. DTO](#133-dto)
    - [1.3.4. Enums](#134-enums)
    - [1.3.5. Events](#135-events)
    - [1.3.6. Interfaces](#136-interfaces)
    - [1.3.7. Models](#137-models)
    - [1.3.8. Repositories](#138-repositories)
  - [1.4. Installation](#14-installation)

# 1. Airport Project - Common

An ASP.NET Core 5.0 project that is the handler of all the objects which are common to multiple projects.

## 1.1. Motivation

In order to keep things readable and simple, the project is broken down to small units [(SOC)](https://en.wikipedia.org/wiki/Separation_of_concerns).

The Common project is the center of the SoC, as it depends on nothing, but everything depends on it.

This means that the Common project is the base of all the shared parts in the project.

## 1.2. Tech & frameworks used

-   [C# 9.0](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9) and [.Net 5](https://github.com/dotnet/core/tree/master/release-notes/5.0).

## 1.3. Structure

The project is built of multiple parts:


-   [Constants](#131-constants)
-   [Data structeres](#132-data)
-   [Data Transfer Objects](#133-dto)
-   [Enums](#134-enums)
-   [Event](#135-events)
-   [Interfaces](#136-interfaces)
-   [Models](#137-models)
-   [Repositories](#138-repositories)
  
### 1.3.1. Constants

Constant data which should be used through out the app instead of hardcoded values.

### 1.3.2. Data

Data structers built to handle edge cases of the app:

-   A Queue which enables adding to front of line, to secure flight moving in to station more than once.

### 1.3.3. DTO

Data Transfer Objects to enable passing data on to the UI without recursive object relations.

### 1.3.4. Enums

Enums used through out the project.

### 1.3.5. Events

Event arguments used through out the project.

### 1.3.6. Interfaces

The Interfaces that make the API of the BL, as well as define some of the types of the DB models.

### 1.3.7. Models

The Models for the DB, which are also used widely through out the app.

### 1.3.8. Repositories

The interfaces of the repositories used through out the app.

## 1.4. Installation

The Common project is not a standalone project, and is simply the smallest building block of the project.

In order to run the server you could:

1.  Go to the [releases page](https://github.com/ChemiAtlow/AirportProject/releases/latest) and download the latest Server asset for your OS.
2.  Clone the project and build the ASP.NET server project to fire-up the API server.
3.  Clone the project, and run docker compose to start a Nginx server containig the Server and the UI.
    ```bash
    docker-compose up --build
    ```
