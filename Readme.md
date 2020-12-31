# Airport Project 🛫

A e2e project that handles incoming/outgoing flights from control towers.

Includes:

- 👓 Rest API that handles all the logic (in Asp.Net core).
- 🎚 Simulator that generate new flights and sends them to the API (.Net Console app).
- 🖥 Web app for displaying the movement of the flights (Vue 3).
- 💾 Database (in Sqlite)

## Table of Contents

- [1. Motivation](#1-motivation)
- [2. Build status](#2-build-status)
- [3. Tech & frameworks used](#3-tech--frameworks-used)
  - [3.1. Backend](#31-backend)
  - [3.2. Frontend](#32-frontend)
  - [3.3. General](#33-general)
- [4. Structure](#4-structure)
  - [4.1. Server](#41-server)
  - [4.2. UI](#42-ui)
  - [4.3. Simulator](#43-simulator)
- [5. Installation](#5-installation)
- [6. License](#6-license)

## 1. Motivation

A system that handles arriving and outgoing flights from and to control towers, including the travel of the flight between different stations through out the airport.
Built as the final project for the Fullstack studies in Sela college.

## 2. Build status

[![workflow state](https://github.com/ChemiAtlow/AirportProject/workflows/Build%20and%20Run%20tests./badge.svg?event=push "Build status")](https://github.com/ChemiAtlow/AirportProject/actions?query=workflow%3A%22Build+and+Run+tests.%22)
[![GitHub release (latest by date)](https://img.shields.io/github/v/release/ChemiAtlow/AirportProject?label=latest%20version&style=flat-square "Latest version")](https://github.com/ChemiAtlow/AirportProject/releases/latest)

## 3. Tech & frameworks used

### 3.1. Backend

-   [C# 9.0](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9) and [.Net 5.](https://github.com/dotnet/core/tree/master/release-notes/5.0)
-   [EFCore](https://github.com/dotnet/efcore).
-   [SignalR](https://github.com/dotnet/aspnetcore/tree/master/src/SignalR).

### 3.2. Frontend

-   [Typescript](https://github.com/microsoft/TypeScript).
-   [SASS](https://github.com/sass/sass).
-   [Vue 3](https://github.com/vuejs/vue-next).

### 3.3. General
- [Docker](https://github.com/docker).
- [Nginx](https://github.com/nginx/nginx).

## 4. Structure

The project is built of three main building blocks:

-   [Server](#141-server).
-   [Control Tower UI](#142-ui).
-   [Flight Simulator](#143-simulator) (Create flights and send to the API).

### 4.1. Server

-   Swagger view of all possible endpoints.
-   Endpoints for getting data by control tower, or station Id.
-   Endpoint for posting a Flight.
-   SignalR hub for live UI updates.

### 4.2. UI

-   Two tables: takeoff / landing flights.
-   Station state view:
    -   List view - A list of stations and their current state.
    -   Flow chart - A live flow chart of the stations and flights.

### 4.3. Simulator

-   Console app.
-   Generate random flights, with random delays.
-   Sends flight to the API.
-   Prints the flight data.

## 5. Installation

-   Go to the [releases page](https://github.com/ChemiAtlow/AirportProject/releases/latest) and download the latest assets for your OS.
-   Clone the project, and build the wanted projects.
-   Clone the project, and run docker compose to start a Nginx server containig the Server and the UI.
    ```bash
    docker-compose up --build
    ```

## 6. License

[MIT](https://choosealicense.com/licenses/mit/)
