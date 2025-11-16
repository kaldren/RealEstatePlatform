using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using REP.Modules.Listings.Application.Contracts;
using REP.Modules.Listings.Infrastructure.Persistence;
using REP.Modules.Listings.Infrastructure.Persistence.Repositories;

namespace REP.Modules.Listings.Infrastructure.Extensions;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddListingsInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        // Example of using the configuration
        var connectionString = config["Modules:Listings:Database:ConnectionString"];
        services.AddDbContext<ListingsDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IListingsRepository, ListingsRepository>();

        return services;
    }
}
