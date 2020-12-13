- [1. Airport Project](#1-airport-project)
  - [1.1. Motivation](#11-motivation)
  - [1.2. Build status](#12-build-status)
  - [1.3. Tech & frameworks used](#13-tech--frameworks-used)
    - [1.3.1. Backend](#131-backend)
    - [1.3.2. Frontend](#132-frontend)
    - [1.3.3. General](#133-general)
  - [1.4. Structure](#14-structure)
    - [1.4.1. Server](#141-server)
    - [1.4.2. UI](#142-ui)
    - [1.4.3. Simulator](#143-simulator)
  - [1.5. Installation](#15-installation)
  - [1.6. License](#16-license)

# 1. Airport Project

A e2e project that handles incoming/outgoing flights from control towers.

## 1.1. Motivation

A system that handles arriving and outgoing flights from and to control towers, including the travel of the flight between different stations through out the airport.
Built as the final project for the Fullstack studies in Sela college.

## 1.2. Build status

[![workflow state](https://github.com/ChemiAtlow/AirportProject/workflows/Build%20and%20Run%20tests./badge.svg?event=push "Build status")](https://github.com/ChemiAtlow/AirportProject/actions?query=workflow%3A%22Build+and+Run+tests.%22)
[![GitHub release (latest by date)](https://img.shields.io/github/v/release/ChemiAtlow/AirportProject?label=latest%20version&style=flat-square "Latest version")](https://github.com/ChemiAtlow/AirportProject/releases/latest)

## 1.3. Tech & frameworks used

### 1.3.1. Backend

-   [C# 9.0](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9) and [.Net 5.](https://github.com/dotnet/core/tree/master/release-notes/5.0)
-   [EFCore](https://github.com/dotnet/efcore).
-   [SignalR](https://github.com/dotnet/aspnetcore/tree/master/src/SignalR).

### 1.3.2. Frontend

-   [Typescript](https://github.com/microsoft/TypeScript).
-   [SASS](https://github.com/sass/sass).
-   [Vue 3](https://github.com/vuejs/vue-next).

### 1.3.3. General
- [Docker](https://github.com/docker).
- [Nginx](https://github.com/nginx/nginx).

## 1.4. Structure

The project is built of three main building blocks:

-   [Server](#141-server).
-   [Control Tower UI](#142-ui).
-   [Flight Simulator](#143-simulator) (Create flights and send to the API).

### 1.4.1. Server

-   Swagger view of all possible endpoints.
-   Endpoints for getting data by control tower, or station Id.
-   Endpoint for posting a Flight.
-   SignalR hub for live UI updates.

### 1.4.2. UI

-   Two tables: takeoff / landing flights.
-   Station state view:
    -   List view - A list of stations and their current state.
    -   Flow chart - A live flow chart of the stations and flights.

### 1.4.3. Simulator

-   Console app.
-   Generate random fkights, with random delays.
-   Sends flight to the API.
-   Prints the flight data.

## 1.5. Installation

-   Go to the [releases page](https://github.com/ChemiAtlow/AirportProject/releases/latest) and download the latest assets for your OS.
-   Clone the project, and build the wanted projects.
-   Clone the project, and run docker compose to start a Nginx server containig the Server and the UI.
    ```bash
    docker-compose up --build
    ```

## 1.6. License

[MIT](https://choosealicense.com/licenses/mit/)