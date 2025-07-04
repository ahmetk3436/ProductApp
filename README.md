# ProductApp - Clean Architecture Product Management API

## Overview

ProductApp is a modern .NET 7 Web API application built using Clean Architecture principles. It provides a RESTful API for managing products with CQRS (Command Query Responsibility Segregation) pattern implementation using MediatR.

## 🏗️ Architecture

The application follows Clean Architecture principles with clear separation of concerns:

```
src/
├── Core/
│   ├── ProductApp.Domain/          # Domain entities and business rules
│   └── ProductApp.Application/      # Application logic, CQRS handlers, DTOs
├── Infrastructure/
│   └── Persistence/                 # Data access layer with Entity Framework
└── WebApi/
    └── ProductApp.WebApi/          # API controllers and configuration
```

### Layers Description

- **Domain Layer**: Contains core business entities and domain logic
- **Application Layer**: Implements use cases using CQRS pattern with MediatR
- **Infrastructure Layer**: Handles data persistence using Entity Framework Core
- **WebApi Layer**: Exposes REST endpoints and handles HTTP requests

## 🚀 Technologies Used

- **.NET 7**: Latest .NET framework
- **ASP.NET Core Web API**: For building REST APIs
- **Entity Framework Core 7.0.3**: ORM for data access
- **In-Memory Database**: For development and testing
- **MediatR 12.0.0**: For implementing CQRS pattern
- **AutoMapper 12.0.1**: For object-to-object mapping
- **Swagger/OpenAPI**: For API documentation
- **Clean Architecture**: For maintainable and testable code structure

## 📋 Features

### Product Management
- **Create Product**: Add new products with name, quantity, and quality
- **Get All Products**: Retrieve list of all products
- **Get Product by ID**: Retrieve specific product details

### API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/Product` | Get all products |
| GET | `/api/Product/{id}` | Get product by ID |
| POST | `/api/Product` | Create new product |

### Product Model

```csharp
public class Product
{
    public Guid Id { get; set; }           // Unique identifier
    public DateTime CreateDate { get; set; } // Creation timestamp
    public string? Name { get; set; }       // Product name
    public int Quantity { get; set; }       // Available quantity
    public int Quality { get; set; }        // Quality rating
}
```

## 🛠️ Getting Started

### Prerequisites

- .NET 7 SDK
- Visual Studio 2022 or VS Code
- Git

### Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd ProductApp
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Build the solution**
   ```bash
   dotnet build
   ```

4. **Run the application**
   ```bash
   cd src/WebApi/ProductApp.WebApi
   dotnet run
   ```

5. **Access the API**
   - API Base URL: `https://localhost:7xxx` or `http://localhost:5xxx`
   - Swagger UI: `https://localhost:7xxx/swagger`

## 📖 API Usage Examples

### Create a Product

```bash
curl -X POST "https://localhost:7xxx/api/Product" \
     -H "Content-Type: application/json" \
     -d '{
       "name": "Sample Product",
       "quantity": 100,
       "quality": 5
     }'
```

### Get All Products

```bash
curl -X GET "https://localhost:7xxx/api/Product"
```

### Get Product by ID

```bash
curl -X GET "https://localhost:7xxx/api/Product/{product-id}"
```

## 🏛️ Design Patterns

### CQRS (Command Query Responsibility Segregation)
- **Commands**: Handle write operations (CreateProductCommand)
- **Queries**: Handle read operations (GetAllProductsQuery, GetProductByIdQuery)

### Repository Pattern
- Abstracts data access logic
- Provides testable data layer

### Mediator Pattern
- Decouples request/response handling
- Centralizes cross-cutting concerns

## 🗂️ Project Structure Details

### Domain Layer (`ProductApp.Domain`)
- `Entities/Product.cs`: Core product entity
- `Common/BaseEntity.cs`: Base entity with common properties

### Application Layer (`ProductApp.Application`)
- `Features/Commands/`: Command handlers for write operations
- `Features/Queries/`: Query handlers for read operations
- `Dto/`: Data transfer objects
- `Interfaces/`: Repository interfaces
- `Mapping/`: AutoMapper profiles
- `Wrapper/`: Response wrapper classes

### Infrastructure Layer (`ProductApp.Persistence`)
- `Context/`: Entity Framework DbContext
- `Repositories/`: Repository implementations
- `ServiceRegistration.cs`: Dependency injection configuration

### WebApi Layer (`ProductApp.WebApi`)
- `Controllers/ProductController.cs`: REST API endpoints
- `Program.cs`: Application startup and configuration

## 🔧 Configuration

The application uses in-memory database for development. Configuration can be modified in:
- `appsettings.json`: General application settings
- `appsettings.Development.json`: Development-specific settings

## 🧪 Testing

The application is designed with testability in mind:
- Clean separation of concerns
- Dependency injection
- Repository pattern for data access
- CQRS for business logic separation

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## 📄 License

This project is licensed under the MIT License.

## 📞 Support

For questions and support, please open an issue in the repository.

---

**Built with ❤️ using Clean Architecture and .NET 7**