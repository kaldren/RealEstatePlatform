using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using REP.Modules.Listings.Infrastructure.Extensions;
using REP.Shared.Mediator.Extensions;
using REP.Modules.Listings.API;
using REP.Modules.Listings.Infrastructure.Persistence;
using REP.Modules.Accounts.API;
using REP.Modules.Accounts.Infrastructure.Extensions;

bool isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
bool insertDummyData = true;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddMediator();

builder.Services.AddListingsInfrastructure(builder.Configuration);
builder.Services.AddAccountsInfrastructure(builder.Configuration);

var app = builder.Build();

if (isDevelopment && insertDummyData)
{
    using (var scope = app.Services.CreateScope())
    {
        await SetupDatabase.InitializeAsync(scope.ServiceProvider.GetRequiredService<ListingsDbContext>());
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapListingsEndpoints();
app.MapAccountsEndpoints();

app.MapControllers();

app.Run();
