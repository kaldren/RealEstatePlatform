using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using REP.Modules.Listings.Infrastructure.Extensions;
using REP.Shared.Mediator.Extensions;
using REP.Modules.Listings.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddMediator();

builder.Services.AddListingsModule(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();
app.MapListingsEndpoints();
app.MapControllers();

app.Run();
