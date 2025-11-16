using Microsoft.Extensions.DependencyInjection;
using REP.Shared.Mediator.Contracts;

namespace REP.Shared.Mediator.Extensions;

public static class AddMediatorExtension
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddTransient<IMediator, Mediator>();
        return services;
    }
}
