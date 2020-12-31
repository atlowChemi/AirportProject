# Airport Project - Simulator 🦺

An ASP.NET Core 5.0 console app that simulates landing/taking-off flights in the close future.

## Table of Contents

- [1. Motivation](#1-motivation)
- [2. Tech & frameworks used](#2-tech--frameworks-used)
- [3. Structure](#3-structure)
  - [3.1. API](#31-api)
  - [3.2. Services](#32-services)
- [4. Installation](#4-installation)

## 1. Motivation

The simulator project is an executable that starts generates random flights and sends them on to the API of the project.

## 2. Tech & frameworks used

-   [C# 9.0](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9) and [.Net 5](https://github.com/dotnet/core/tree/master/release-notes/5.0).
-   [SignalR](https://github.com/dotnet/aspnetcore/tree/master/src/SignalR).

## 3. Structure

The project is built of two parts:

- [API](#31-api)
- [Services](#32-services)

Both these parts are later Dependency Injected into the startup of the simulator project.
  
### 3.1. API

The API that defines the services available in the simulator project only.

### 3.2. Services

The services which fill and preform the API requirements.

## 4. Installation

There are a few available methods to run the Simulator project.
1.   Go to the [releases page](https://github.com/ChemiAtlow/AirportProject/releases/latest) and download the latest Simulator asset for your OS.
2.   Clone the project and build the Simulator to fire-up the console app.
