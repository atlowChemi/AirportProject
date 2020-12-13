- [1. Airport Project - BL](#1-airport-project---bl)
  - [1.1. Motivation](#11-motivation)
  - [1.2. Tech & frameworks used](#12-tech--frameworks-used)
  - [1.3. Structure](#13-structure)
    - [1.3.1. Flight Service](#131-flight-service)
    - [1.3.2. Station Service](#132-station-service)
    - [1.3.3. Control Tower Service](#133-control-tower-service)
    - [1.3.4. Airport Service](#134-airport-service)
    - [1.3.5. Airport Events Service](#135-airport-events-service)
    - [1.3.6. Airport DB Service](#136-airport-db-service)
    - [1.3.7. Random Data Generator Service](#137-random-data-generator-service)
    - [1.3.8. Station Tree Builder Service](#138-station-tree-builder-service)
  - [1.4. Installation](#14-installation)

# 1. Airport Project - BL

An ASP.NET Core 5.0 project that is the actual magic of the whole project.

The BL contains all the services that actually run and manage the airports.

## 1.1. Motivation

In order to keep things readable and simple, the project is broken down to small units [(SOC)](https://en.wikipedia.org/wiki/Separation_of_concerns).

The server doesn't actually do anything on it's own, and any request it gets will be fully handled by a service which lives in this project.

## 1.2. Tech & frameworks used

-   [C# 9.0](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9) and [.Net 5](https://github.com/dotnet/core/tree/master/release-notes/5.0).

## 1.3. Structure

The project is built of multiple services:

-   Logical wrappers for DB elements:
    -   [FlightService](#131-flight-service).
    -   [StationService](#132-station-service).
    -   [ControlTowerService](#133-control-tower-service).
-   Services which run the core logic
    -   [AirportService](#134-airport-service).
    -   [AirportEventsService](#135-airport-events-service).
    -   [AirportDBService](#136-airport-db-service).
    -   [RandomDataGeneratorService](#137-random-data-generator-service).
    -   [StationTreeBuilderService](#138-station-tree-builder-service).
  
### 1.3.1. Flight Service

A transient service which is the loggical wrapper of the flights.

Created for each flight which leaves the control-tower and starts the journey through the airport's stations.

### 1.3.2. Station Service

A transient service which is the loggical wrapper of the airport's stations.

Created for each station from the DB, and connected to the continuation stations for both directions (land & takeoff), if any exist.

Handles the arrival of a flight to the station, and the movement of the flight to the next station, once the flight is ready to move, and a next station is available.

### 1.3.3. Control Tower Service

A transient service which is the loggical wrapper of the control towers.

Created for each control tower from the DB, and connected to the first stations for both directions (land & takeoff).

Handles the flights which have arrived to the airport and are now waiting to start the journey in the airport's stations.

Queues landing and taking-off flights to enable them to pass to next stations.

### 1.3.4. Airport Service

The conductor of the airport.

A scoped service, which is the only service the API reaches out to.

This service handles all the requests related to the airport, and runs all the required services.

### 1.3.5. Airport Events Service

The manager of flight movement events.

A singelton service which registers to all stations, and invokes the [DB updating service](#135-airport-db-service) as well as the SignalR hub to notify the UI as well as the DB.  

### 1.3.6. Airport DB Service

The manager of DB updates.

A singelton service which is the only service which reaches to the repository for writing and updating data.

### 1.3.7. Random Data Generator Service

A singelton service which ramdomly generates data.

### 1.3.8. Station Tree Builder Service

A singelton service which handles the creation of all the **logical** Control towers and stations, and after creating them creates the connections with the propper continuation stations.

## 1.4. Installation

The BL project is not a standalone project, and is simply the engine for the Server project.

In order to run the server you could:

1.  Go to the [releases page](https://github.com/ChemiAtlow/AirportProject/releases/latest) and download the latest Server asset for your OS.
2.  Clone the project and build the ASP.NET server project to fire-up the API server.
3.  Clone the project, and run docker compose to start a Nginx server containig the Server and the UI.
    ```bash
    docker-compose up --build
    ```
