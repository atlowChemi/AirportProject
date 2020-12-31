# Airport Project - Common 👨‍👩‍👦

An ASP.NET Core 5.0 project that is the handler of all the objects which are common to multiple projects.

## Table of Contents

  - [1. Motivation](#1-motivation)
  - [2. Tech & frameworks used](#2-tech--frameworks-used)
  - [3. Structure](#3-structure)
    - [3.1. Constants](#31-constants)
    - [3.2. Data](#32-data)
    - [3.3. DTO](#33-dto)
    - [3.4. Enums](#34-enums)
    - [3.5. Events](#35-events)
    - [3.6. Interfaces](#36-interfaces)
    - [3.7. Models](#37-models)
    - [3.8. Repositories](#38-repositories)
  - [4. Installation](#4-installation)


## 1. Motivation

In order to keep things readable and simple, the project is broken down to small units [(SOC)](https://en.wikipedia.org/wiki/Separation_of_concerns).

The Common project is the center of the SoC, as it depends on nothing, but everything depends on it.

This means that the Common project is the base of all the shared parts in the project.

## 2. Tech & frameworks used

-   [C# 9.0](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9) and [.Net 5](https://github.com/dotnet/core/tree/master/release-notes/5.0).

## 3. Structure

The project is built of multiple parts:


-   [Constants](#31-constants)
-   [Data Structeres](#32-data)
-   [Data Transfer Objects](#33-dto)
-   [Enums](#34-enums)
-   [Event Argumanets](#35-events)
-   [Interfaces](#36-interfaces)
-   [Models](#37-models)
-   [Repositories](#38-repositories)
  
### 3.1. Constants

Constant data which should be used through out the app instead of hardcoded values.

### 3.2. Data

Data structers built to handle edge cases of the app:

-   A Queue which enables adding to front of line, to secure flight moving in to station more than once.

### 3.3. DTO

Data Transfer Objects to enable passing data on to the UI without recursive object relations.

### 3.4. Enums

Enums used through out the project.

### 3.5. Events

Event arguments used through out the project.

### 3.6. Interfaces

The Interfaces that make the API of the BL, as well as define some of the types of the DB models.

### 3.7. Models

The Models for the DB, which are also used widely through out the app.

### 3.8. Repositories

The interfaces of the repositories used through out the app.

## 4. Installation

The Common project is not a standalone project, and is simply the smallest building block of the project.

In order to run the server you could:

1.  Go to the [releases page](https://github.com/ChemiAtlow/AirportProject/releases/latest) and download the latest Server asset for your OS.
2.  Clone the project and build the ASP.NET server project to fire-up the API server.
3.  Clone the project, and run docker compose to start a Nginx server containig the Server and the UI.
    ```bash
    docker-compose up --build
    ```
