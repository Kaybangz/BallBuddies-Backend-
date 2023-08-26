## Introduction

An API for the BallBuddies web app, designed to facilitate sports enthusiasts in creating, managing, and attending sport events. The API supports basic CRUD operations for events and user interactions.

## Features
Some of the features include:

1. ***Create Events***: Endpoint to allow users to create new sport events, providing event details such as sport type, location, date, and time.
2. ***View Events***: Endpoint to fetch a list of upcoming sport events, including information about the event creator, sport type, price etc.
3. ***Attend Events***: Endpoint to enable users to join and attend events created by other users. The event attendance count is updated accordingly.
4. ***Manage Events***: Endpoint for event creators to manage their created events, enabling them to update event details, delete events, or remove attendees.
   
## Technology used
* C# 10.0
* .Net 6.0

## Run Locally

* Clone the project

```bash
  git clone https://link-to-project
```

* Open project folder in Visual studio or Visual studio code

* Navigate to the `BallBuddies` project, open the `appsettings.json` file and change the `ConnectionStrings/DbConnection` to your own local database connection string.

* Also change the `JwtSettings/validAudience` to your own local development URL

* Open your terminal and run this command ``` setx SECRET "{enter your secret key}" /M ``` to set a secret key

## Layout

```tree
├── Solution Items
├── BallBuddies
├── BallBuddies.Data
├── BallBuddies.Models
├── BallBuddies.Presentation
├── BallBuddies.Services

```

* `BallBuddies` contains the `program.cs` and `appsettings.json` files

* `BallBuddies.Data` contains folders for role cofiguration, migrations, DbContext, interfaces and implementations for all the model repositories and generic repository.

* `BallBuddies.Models` contains folders for data transfer objects(DTO's), automapper mapping configurations, enums, global error handling.

* `BallBuddies.Presentation` contains folders for the controllers and model bindings

* `BallBuddies.Services` contains folders for Action filters, custom formatters, service extension methods, interfaces and implementations for all the model services and service manager



## Support

Please support me by giving the project a star ⭐
