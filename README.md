# Courier Delivery System

A console-based courier management application built in C# that demonstrates core Object-Oriented Programming (OOP) principles, generic collections, and safe user input handling.

## Features

- **Create Shipments:** Support for both **Standard** and **Express** deliveries with automatic ID generation and dynamic price calculation.
- **Shipment Insurance:** Express shipments support optional declared-value insurance through explicit interface implementation.
- **Status Lifecycle Management:** Enforces valid state transitions (`Created` -> `InTransit` -> `Delivered`, or `Created` -> `Cancelled`).
- **Registry Management:** View all active shipments, search by shipment number, and delete records from memory.
- **Input Validation:** Protected against invalid numeric inputs, empty text fields, and negative values using `TryParse` and exception handling.

## Project Structure

- `Shipment.cs` — Abstract base class defining common properties, status transition rules, and polymorphic pricing.
- `StandardShipment.cs` — Standard delivery implementation with base and per-kilogram pricing.
- `ExpressShipment.cs` — Express delivery implementation with priority rates and insurance support.
- `IInsurable.cs` — Interface defining insurance behavior (`Insure`, `CalculateInsurance`).
- `ShipmentStatus.cs` — Enum representing the shipment lifecycle states.
- `Registry<T>.cs` — Generic collection class acting as an in-memory data store.
- `Program.cs` — Interactive console menu and user input validation.
