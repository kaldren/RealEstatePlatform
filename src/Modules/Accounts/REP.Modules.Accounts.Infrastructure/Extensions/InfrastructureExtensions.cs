using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using REP.Modules.Accounts.Application.Contracts;
using REP.Modules.Accounts.Infrastructure.Persistence;
using REP.Modules.Accounts.Infrastructure.Persistence.Repositories;

namespace REP.Modules.Accounts.Infrastructure.Extensions;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddAccountsInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        // Example of using the configuration
        var connectionString = config["Modules:Accounts:Database:ConnectionString"];
        services.AddDbContext<AccountsDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IAccountsRepository, AccountsRepository>();

        return services;
    }
}
