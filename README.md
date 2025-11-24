## Request & Response Flow

The system uses **CQRS** (Command–Query Responsibility Segregation) together with **Clean Architecture** and **Vertical Slice Architecture**.  
Each API request is mapped to a specific use case (Command or Query), handled inside the Application layer, and returns a dedicated ResponseModel.

# Request Flow (Write or Read)

1. **Client sends a RequestModel** to the API endpoint.
2. **API maps RequestModel to Command/Query** (input DTO for the Application layer).
3. **Command/Query is sent to its handler** via mediator.
4. **Handler executes the use case**, calling:
   - Repositories (Infrastructure)  
   - Services inside the module  
5. **Repository returns a Domain Entity** to the handler.
6. **Handler maps Entity to response model (e.g., `ListingResponseModel`)** defined in the Application layer.

# Response Flow

1. **Application layer returns response model** back to the API.
2. **API returns the response model directly to the client** (no extra mapping, no domain exposure).
3. **Client receives a clean, use-case-specific response**, isolated from domain and infrastructure details.

# Summary of Responsibilities

### **API Layer**
- Receives `request model`
- Maps to Command/Query
- Sends to mediator
- Returns `response model`

### **Application Layer**
- Contains Commands, Queries, Handlers
- Defines RequestModels and ResponseModels
- Orchestrates use case execution
- Converts Domain Entities to DTOs

### **Domain Layer**
- Pure business logic
- Entities, Value Objects, Domain Events
- No DTOs, no HTTP concerns

### **Infrastructure Layer**
- Repositories and EF Core data access
- Persistence logic only
- No RequestModels or ResponseModels

# Listing Module

To run the migrations for the Listing Module, follow these steps:
1. Open your terminal or command prompt.
2. Go to the root directory of your project.
3. Execute the following command to apply the migrations:
```
dotnet ef migrations add MIGRATION_NAME --project .\src\Modules\Listings\REP.Modules.Listings.Infrastructure --startup-project .\src\REP.API --output-dir Persistence/Migrations
dotnet ef database update --project .\src\REP.API

Example: 
dotnet ef migrations add InitAccs2 --project .\src\Modules\Accounts\REP.Modules.Accounts.Infrastructure --startup-project .\src\REP.API --output-dir Persistence/Migrations --context AccountsDbContext
dotnet ef database update --project .\src\Modules\Accounts\REP.Modules.Accounts.Infrastructure --startup-project .\src\REP.API --context AccountsDbContext
```