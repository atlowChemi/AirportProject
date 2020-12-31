# Airport Project - BL 🧠

An ASP.NET Core 5.0 project that is the actual magic of the whole project.

The BL contains all the services that actually run and manage the airports.

## Table of Contents

- [1. Motivation](#1-motivation)
- [2. Tech & frameworks used](#2-tech--frameworks-used)
- [3. Structure](#3-structure)
  - [3.1. Flight Service](#31-flight-service)
  - [3.2. Station Service](#32-station-service)
  - [3.3. Control Tower Service](#33-control-tower-service)
  - [3.4. Airport Service](#34-airport-service)
  - [3.5. Airport Events Service](#35-airport-events-service)
  - [3.6. Airport DB Service](#36-airport-db-service)
  - [3.7. Random Data Generator Service](#37-random-data-generator-service)
  - [3.8. Station Tree Builder Service](#38-station-tree-builder-service)
- [4. Installation](#4-installation)

## 1. Motivation

In order to keep things readable and simple, the project is broken down to small units [(SOC)](https://en.wikipedia.org/wiki/Separation_of_concerns).

The server doesn't actually do anything on it's own, and any request it gets will be fully handled by a service which lives in this project.

## 2. Tech & frameworks used

-   [C# 9.0](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9) and [.Net 5](https://github.com/dotnet/core/tree/master/release-notes/5.0).

## 3. Structure

The project is built of multiple services:

-   Logical wrappers for DB elements:
    -   [FlightService](#31-flight-service).
    -   [StationService](#32-station-service).
    -   [ControlTowerService](#33-control-tower-service).
-   Services which run the core logic
    -   [AirportService](#34-airport-service).
    -   [AirportEventsService](#35-airport-events-service).
    -   [AirportDBService](#36-airport-db-service).
    -   [RandomDataGeneratorService](#37-random-data-generator-service).
    -   [StationTreeBuilderService](#38-station-tree-builder-service).

Service life-cycle table:

| Singelton                                                        | Scoped                                                                                       | Transient                                   |
| ---------------------------------------------------------------- | -------------------------------------------------------------------------------------------- | ------------------------------------------- |
| [AirportEventService](#35-airport-events-service)               | [AirportService](#34-airport-service)                                                       | [Flight](#31-flight-service)               |
| [AirportDBService](#36-airport-db-service)                      | [Repositories](https://github.com/ChemiAtlow/AirportProject/tree/master/Common/Repositories) | [Station](#32-station-service)             |
| [RandomDataGeneratorService](#37-random-data-generator-service) |                                                                                              | [Control tower](#33-control-tower-service) |
| [StationTreeBuilderService](#38-station-tree-builder-service)   |                                                                                              |                                             |


### 3.1. Flight Service

A transient service which is the loggical wrapper of the flights.

Created for each flight which leaves the control-tower and starts the journey through the airport's stations.

### 3.2. Station Service

A transient service which is the loggical wrapper of the airport's stations.

Created for each station from the DB, and connected to the continuation stations for both directions (land & takeoff), if any exist.

Handles the arrival of a flight to the station, and the movement of the flight to the next station, once the flight is ready to move, and a next station is available.

### 3.3. Control Tower Service

A transient service which is the loggical wrapper of the control towers.

Created for each control tower from the DB, and connected to the first stations for both directions (land & takeoff).

Handles the flights which have arrived to the airport and are now waiting to start the journey in the airport's stations.

Queues landing and taking-off flights to enable them to pass to next stations.

### 3.4. Airport Service

The conductor of the airport.

A scoped service, which is the only service the API reaches out to.

This service handles all the requests related to the airport, and runs all the required services.

### 3.5. Airport Events Service

The manager of flight movement events.

A singelton service which registers to all stations, and invokes the [DB updating service](#36-airport-db-service) as well as the SignalR hub to notify the UI as well as the DB.  

### 3.6. Airport DB Service

The manager of DB updates.

A singelton service which is the only service which reaches to the repository for writing and updating data.

### 3.7. Random Data Generator Service

A singelton service which ramdomly generates data.

### 3.8. Station Tree Builder Service

A singelton service which handles the creation of all the **logical** Control towers and stations, and after creating them creates the connections with the propper continuation stations.

## 4. Installation

The BL project is not a standalone project, and is simply the engine for the Server project.

In order to run the server you could:

1.  Go to the [releases page](https://github.com/ChemiAtlow/AirportProject/releases/latest) and download the latest Server asset for your OS.
2.  Clone the project and build the ASP.NET server project to fire-up the API server.
3.  Clone the project, and run docker compose to start a Nginx server containig the Server and the UI.
    ```bash
    docker-compose up --build
    ```
