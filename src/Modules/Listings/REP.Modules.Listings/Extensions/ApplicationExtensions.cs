using Microsoft.Extensions.DependencyInjection;
using REP.Modules.Listings.Application.Contracts;
using REP.Modules.Listings.Application.Services;

namespace REP.Modules.Listings.Application.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddListingsApplications(this IServiceCollection services)
    {
        services.AddTransient<IListingsService, ListingsService>();

        return services;
    }
}
