using Microsoft.Extensions.DependencyInjection;
using RealEstatePlatform.Shared.Mediator.Contracts;

namespace RealEstatePlatform.Shared.Mediator.Extensions;

public static class AddMediatorExtension
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddTransient<IMediator, Mediator>();
        return services;
    }
}
