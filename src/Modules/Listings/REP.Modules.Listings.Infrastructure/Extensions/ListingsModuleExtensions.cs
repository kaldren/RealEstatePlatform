using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using REP.Modules.Listings.Infrastructure.Persistence;

namespace REP.Modules.Listings.Infrastructure.Extensions;

public static class ListingsModuleExtensions
{
    public static IServiceCollection AddListingsModule(this IServiceCollection services, IConfiguration config)
    {
        // Example of using the configuration
        var connectionString = config["Modules:Listings:Database:ConnectionString"];
        services.AddDbContext<ListingsDbContext>(options =>
            options.UseSqlServer(connectionString));

        return services;
    }
}
