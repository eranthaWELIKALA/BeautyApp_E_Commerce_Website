# BeautyApp

BeautyApp is a comprehensive ASP.NET Core application featuring user authentication, product management, shopping cart functionality, and order processing.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Setup](#setup)
- [Building and Running](#building-and-running)
- [Project Structure](#project-structure)
- [Database Integration](#database-integration)
- [User Roles and Authorization](#user-roles-and-authorization)
- [Product Filtering](#product-filtering)
- [Order Management](#order-management)

## Features

- User authentication (Admin and Customer roles)
- Product management (CRUD operations)
- Shopping cart functionality
- Order processing
- Product filtering
- Access denied page for unauthorized access
- User profile management

## Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Bootstrap
- Identity

## Setup

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 5.0 or later)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio](https://visualstudio.microsoft.com/) (recommended)

### Clone the Repository

```bash
git clone https://github.com/yourusername/BeautyApp.git
cd BeautyApp
```

### Configure the Database

- Update the connection string in appsettings.json:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=your_server;Database=BeautyApp;User Id=your_user;Password=your_password;"
}
```

- Create the database and apply migrations: [Not needed if the database doesn't exist in your servers]
```bash
dotnet ef database update
```

### Seed the Database
To seed the database with initial data, add seed data in the ApplicationDbContext class. This could include default admin users, products, etc.

```csharp
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    // Your DbSet properties

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Seed data here
        // Example:
        builder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Product1", Price = 10.0 },
            new Product { Id = 2, Name = "Product2", Price = 20.0 }
        );
    }
}
```

### Building and Running

#### Using .NET CLI
```bash
dotnet build
dotnet run
```

#### Using Visual Studio
1. Open the solution file (BeautyApp.sln).
2. Set the project as the startup project.
3. Press F5 to build and run the project.

## Project Structure

```plaintext
BeautyApp/
├── Controllers/
├── Data/
├── Models/
├── Services/
├── Views/
├── wwwroot/
├── appsettings.json
└── Program.cs
```

## Database Integration

Entity Framework Core handles database integration. Ensure your connection string is updated in appsettings.json and apply migrations using dotnet ef database update.

## User Roles and Authorization

ASP.NET Core Identity manages authentication with role-based access control for Admin and Customer roles.

## Product Filtering

Implemented using query parameters and form submissions, allowing dynamic updates to product listings.

## Order Management
Users can place orders, including details like receiver's name, contact number, and address.

## Screenshots
![BeautyApp - Login](https://github.com/eranthaWELIKALA/e-commerce-dot-net-core-mvc/assets/33684206/d128af06-5b0e-4b7d-ab1f-32a75872ec5b)
![BeautyApp - Register](https://github.com/eranthaWELIKALA/e-commerce-dot-net-core-mvc/assets/33684206/28cd1fcf-43cf-40bc-be8a-6fdb2a4fc64c)
![BeautyApp - Store](https://github.com/eranthaWELIKALA/e-commerce-dot-net-core-mvc/assets/33684206/c4d2db0c-686e-4e0a-a31f-543b981d9374)
![BeautyApp - Cart](https://github.com/eranthaWELIKALA/e-commerce-dot-net-core-mvc/assets/33684206/381dd433-93bd-42ac-8c82-4c43984b1a17)
![Screenshot 2024-06-19 005701](https://github.com/eranthaWELIKALA/e-commerce-dot-net-core-mvc/assets/33684206/d1bb0e9d-616f-4930-a931-e8b65e788abf)
![BeautyApp - Order History](https://github.com/eranthaWELIKALA/e-commerce-dot-net-core-mvc/assets/33684206/9a53f623-4c9f-4bef-9299-278a526644eb)
![Screenshot 2024-06-19 005816](https://github.com/eranthaWELIKALA/e-commerce-dot-net-core-mvc/assets/33684206/2568412d-440e-4e63-b130-10a3d1696e87)
![BeautyApp - Order History View](https://github.com/eranthaWELIKALA/e-commerce-dot-net-core-mvc/assets/33684206/d792646b-7075-44d7-84ae-01be57e90a25)
![BeautyApp - Home](https://github.com/eranthaWELIKALA/e-commerce-dot-net-core-mvc/assets/33684206/506f050f-016e-4103-ba1e-f2d642dcda40)

