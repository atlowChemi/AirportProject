- [1. Airport Project - Simulator](#1-airport-project---simulator)
  - [1.1. Motivation](#11-motivation)
  - [1.2. Tech & frameworks used](#12-tech--frameworks-used)
  - [1.3. Structure](#13-structure)
    - [1.3.1. API](#131-api)
    - [1.3.2. Services](#132-services)
  - [1.4. Installation](#14-installation)

# 1. Airport Project - Simulator

An ASP.NET Core 5.0 console app that simulates landing/taking-off flights in the close future.

## 1.1. Motivation

The simulator project is an executable that starts generates random flights and sends them on to the API of the project.

## 1.2. Tech & frameworks used

-   [C# 9.0](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9) and [.Net 5](https://github.com/dotnet/core/tree/master/release-notes/5.0).
-   [SignalR](https://github.com/dotnet/aspnetcore/tree/master/src/SignalR).

## 1.3. Structure

The project is built of two parts:

- [API](#131-api)
- [Services](#132-services)

Both these parts are later Dependency Injected into the startup of the simulator project.
  
### 1.3.1. API

The API that defines the services available in the simulator project only.

### 1.3.2. Services

The services which fill and preform the API requirements.

## 1.4. Installation

There are a few available methods to run the Simulator project.
1.   Go to the [releases page](https://github.com/ChemiAtlow/AirportProject/releases/latest) and download the latest Simulator asset for your OS.
2.   Clone the project and build the Simulator to fire-up the console app.
