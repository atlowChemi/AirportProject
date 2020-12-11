- [1. Airport Project - UI](#1-airport-project---ui)
  - [1.1. Motivation](#11-motivation)
  - [1.2. Tech & frameworks used](#12-tech--frameworks-used)
  - [1.3. Structure](#13-structure)
    - [1.3.1. Server](#131-server)
    - [1.3.2. SPA Vue app](#132-spa-vue-app)
  - [1.4. Installation](#14-installation)

# 1. Airport Project - UI

A Vue project that is a UI for the [Airport server](https://github.com/ChemiAtlow/AirportProject/tree/master/Server).

## 1.1. Motivation

The UI shows a board of incoming and outgoing flights, including the ETA of the flight arrival.
In addition, the UI has a list of all the stations related to the control tower, and there status (occupied, available).

## 1.2. Tech & frameworks used
- [C# 9.0](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9) and [.Net 5.](https://github.com/dotnet/core/tree/master/release-notes/5.0)
-   [Typescript](https://github.com/microsoft/TypeScript).
-   [SASS](https://github.com/sass/sass).
-   [Vue 3](https://github.com/vuejs/vue-next).

## 1.3. Structure

The project is built of two building blocks:

-   [Server](#141-server).
-   [SPA Vue app](#142-ui).

### 1.3.1. Server

A simple ASP.Net Core 5.0 server that serves the SPA app.
  
### 1.3.2. SPA Vue app
A Single Page Apllication, built using the 3rd version of the Vue framework.

The app contains:

-   Takeoff & landing flight tables:
    -   A seperated list of takeoff and landing flights.
    -   Each row reprasents a flight and mentions the ETA and the airport the flight departed from and is targeted to. 
-   Dynamic station state view:
    -   List view - A dynamic list of stations and their current state.
    -   Flow chart - A dynamic flow chart of the stations and flights, with animated updates.

## 1.4. Installation

There are a few available methods to run the UI of this project.
1.   Go to the [releases page](https://github.com/ChemiAtlow/AirportProject/releases/latest) and download the latest WebClient asset for your OS.
2.   Clone the project and build the ASP.NET server to fire-up the UI server.
3.   Clone the project and start the Vue debugging server by entering the [app directory](./app) and running the serve command:
     ```bash
     npm run serve
     ```
4. Clone the project, and run docker compose to start a Nginx server containig the Server and the UI.
    ```bash
    docker-compose up --build
    ```