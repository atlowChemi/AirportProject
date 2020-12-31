# Airport Project - Nginx. 🛶

A [NGINX](https://github.com/nginx/nginx) server to be used as a reverse proxy and serve both the [UI](https://github.com/ChemiAtlow/AirportProject/tree/master/WebClient) and the [Server](https://github.com/ChemiAtlow/AirportProject/tree/master/Server)

## Table of Contents

- [1. Motivation](#1-motivation)
- [2. Tech & frameworks used](#2-tech--frameworks-used)
- [3. Structure](#3-structure)
- [4. How to use](#4-how-to-use)


## 1. Motivation

In order to have only one server exposed, we use the Nginx server as a reverse proxy to expose the UI and the server through a reverse proxy.

This could later be used for load balancing.

## 2. Tech & frameworks used

-   [Docker](https://github.com/docker).
-   [Nginx](https://github.com/nginx/nginx).

## 3. Structure

The project is built of two simple files:

-   [Dockerfile](https://github.com/ChemiAtlow/AirportProject/blob/master/Nginx/Dockerfile) - the setup of the nginx airport image.
-   [Nginx Configuration](https://github.com/ChemiAtlow/AirportProject/blob/master/Nginx/nginx.conf) - Setup of the reverse proxy and the general structure of the nginx server.

## 4. How to use

This projext has no meaning as a standalone, and should only be used via the [docker-compose](https://github.com/ChemiAtlow/AirportProject/blob/master/docker-compose.yml) file in the root.

Simply go to root and run the following command.
```bash
docker-compose up
```
