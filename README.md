# Listing Module

To run the migrations for the Listing Module, follow these steps:
1. Open your terminal or command prompt.
2. Go to the root directory of your project.
3. Execute the following command to apply the migrations:
```
dotnet ef migrations add MIGRATION_NAME --project .\src\Modules\Listings\REP.Modules.Listings.Infrastructure --startup-project .\src\REP.API --output-dir Persistence/Migrations
dotnet ef database update --project .\src\REP.API
```