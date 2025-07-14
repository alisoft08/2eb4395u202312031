# ISA Connect Platform

## Summary
Isa Connect Platform API,
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
This version of Isa Connect Platform is divided into two bounded contexts: Inventory, and Maintenance.

### Inventory Context

The Inventory Context is responsible for managing the products. It includes the following features:

- Create a new product.
- Get all products.
- Get a product by its serial number.

This context includes also an anti-corruption layer to communicate with the Maintenance Context.
The anti-corruption layer is responsible
for managing the communication between the Inventory Context and the Maintenance Context.
It offers the following capabilities to other bounded contexts:

- Get a Product by Serial Number, returning the associated Product ID on success.

### Maintenance Context

The Maintenance Context is responsible for managing the maintenance activities.
Its features include:

- Create a Maintenance Activity.