using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using REP.Modules.Listings.Infrastructure.Extensions;
using REP.Shared.Mediator.Extensions;
using REP.Modules.Listings.API;
using REP.Modules.Listings.Infrastructure.Persistence;
using REP.Modules.Accounts.API;
using REP.Modules.Accounts.Infrastructure.Extensions;
using REP.Modules.Accounts.Infrastructure.Persistence;
using REP.Modules.Reviews.Infrastructure.Extensions;
using REP.Modules.Reviews.Infrastructure.Persistence;

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
builder.Services.AddReviewsInfrastructure(builder.Configuration);

// Add CORS for https://localhost:7146/
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:7146")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (isDevelopment && insertDummyData)
{
    using (var scope = app.Services.CreateScope())
    {
        await ListingsInitDatabase.InitializeAsync(scope.ServiceProvider.GetRequiredService<ListingsDbContext>());
        await AccountsInitDatabase.InitializeAsync(scope.ServiceProvider.GetRequiredService<AccountsDbContext>());
        await ReviewsInitDatabase.InitializeAsync(scope.ServiceProvider.GetRequiredService<ReviewsDbContext>());
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

app.UseCors();

app.MapListingsEndpoints();
app.MapAccountsEndpoints();
app.MapReviewsEndpoints();

app.MapControllers();

app.Run();
