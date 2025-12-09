using Microsoft.Extensions.DependencyInjection;
using REP.Modules.Accounts.Application.Contracts;
using REP.Modules.Accounts.Application.Services;

namespace REP.Modules.Accounts.Application.Extensions;


public static class ApplicationExtensions
{
    public static IServiceCollection AddAccountsApplications(this IServiceCollection services)
    {
        services.AddTransient<IAccountsService, AccountsService>();

        return services;
    }
}
