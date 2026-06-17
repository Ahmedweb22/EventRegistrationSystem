# 📅 Event Registration System (Web API)

A production-ready ASP.NET Core Web API built with **.NET 10** and **SQL Server**, following **Clean Architecture** principles, the **Repository Pattern**, and **SOLID** design principles. The project features a robust business logic layer for event management and seamless integration with **Scalar API Reference** for testing.

---

## 🏗️ Architectural Overview

The project is structured to enforce strong separation of concerns, decoupling the database infrastructure from the core business logic. 

```text
YourProjectName/
│
├── 📁 Configurations/     # Fluent API configurations for Database Tables
├── 📁 Data/               # ApplicationDbContext & Migrations
├── 📁 Entities/           # Database Models / Core Domain Entities
├── 📁 Requests/           # Input Data Transfer Objects (DTOs) from Client
├── 📁 Responses/          # Output Data Transfer Objects (DTOs) to Client
├── 📁 Repositories/       # Data Access Layer (Generic & Specific Repositories)
├── 📁 Services/           # Business Logic & Request-Response Mapping
├── 📁 Controllers/        # API Endpoints (REST Controllers)
└── 📁 Utilities/          # System Constants & Shared Helper Utilities

---

🚀 Core Features & Business Logic
 Decoupled Architecture: Clean separation between database schemas (⁠Entities⁠) and API contracts (⁠Requests⁠/⁠Responses⁠).
 Capacity Validation: Automatic enforcement of maximum event capacity; registrations are rejected once an event is full.
 Duplicate Prevention: Robust validation layer preventing the same user from registering for the same event multiple times.
 Fluent API Isolation: Database table constraints and relations are isolated inside configuration files for a cleaner ⁠DbContext⁠.
 Centralized Messages: System messages and notifications are managed dynamically via a central utility class.
🛣️ API Endpoints Roadmap
👥 Users Management
 ⁠POST /api/users⁠ - Create a new user profile.
 ⁠GET /api/users⁠ - Fetch all registered users.
 ⁠GET /api/users/{id}⁠ - Fetch a specific user by ID.
📅 Events Management
 ⁠POST /api/events⁠ - Create a new event (with capacity control).
 ⁠GET /api/events⁠ - Retrieve all scheduled events.
 ⁠GET /api/events/{id}⁠ - Retrieve details of a specific event.
📝 Registration Desk
 ⁠POST /api/registrations⁠ - Register a user to an event (Validates capacity & duplicates).
 ⁠GET /api/users/{id}/registrations⁠ - Fetch all event registrations for a specific user (includes eager loading of event names).
 ⁠DELETE /api/registrations/{id}⁠ - Cancel an existing registration.
🛠️ Tech Stack & Tools
 Backend Framework: .NET 10 (ASP.NET Core Web API)
 Database Server: Microsoft SQL Server
 ORM: Entity Framework Core 10
 API Documentation & Testing: Scalar API Reference / Postman UI
 IDE: Visual Studio
🏁 Getting Started & Setup
1. Prerequisites
Make sure you have the following installed:
 .NET 9 SDK
 SQL Server LocalDB or Management Studio (SSMS)
2. Database Configuration
Update the connection string inside your ⁠appsettings.json⁠:
  "ConnectionStrings": {
      "DefaultConnection": "Data Source=DESKTOP-9Q6DBR4\\SQL22; Initial Catalog=EventRegistrationSystem;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30"
  }
3. Run Migrations & Start
Open your Package Manager Console or Terminal and run:
# Update the database with the initial schema
dotnet ef database update

# Run the API application
dotnet run

-----

Once started, navigate to ⁠http://localhost:5196/scalar/v1⁠ to explore and interact with the endpoints via the Scalar UI.
Authored with 💻 by Ahmed Elsaid AbdElftah Ahmed
