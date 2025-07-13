# --- Platform

## Summary
--- Platform API,
made with Microsoft C#, ASP.NET Core, Entity Framework Core and MySQL persistence.
It also illustrates open-api documentation configuration and integration with Swagger UI.

## Features
- RESTful API
- OpenAPI Documentation
- Swagger UI
- ASP.NET Framework
- Entity Framework Core
- Audit Creation and Update Date
- Custom Route Naming Conventions
- Custom Object-Relational Mapping Naming Conventions.
- MySQL Database
- Domain-Driven Design

## Bounded Contexts
This version of --- is divided into two bounded contexts: ---, and ---.

### --- Context

The ---' Context is responsible for managing the ---. It includes the following features:

-
-
-


This context includes also an anti-corruption layer to communicate with the --- Context.
The anti-corruption layer is responsible
for managing the communication between the --- Context and the --- Context.
It offers the following capabilities to other bounded contexts:
-
-

### --- Context

The ---' Context is responsible for managing the ---.
Its features include:

-
-
- 