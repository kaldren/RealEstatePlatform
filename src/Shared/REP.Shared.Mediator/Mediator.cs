using Microsoft.Extensions.DependencyInjection;
using REP.Shared.Mediator.Contracts;

namespace REP.Shared.Mediator;

public class Mediator : IMediator
{
    private readonly Dictionary<Type, Type> _handlers = new();
    private readonly IServiceProvider _provider;

    public Mediator(IServiceProvider provider)
    {
        RegisterHandlers();
        _provider = provider;
    }

    private void RegisterHandlers()
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        var handlerTypes = assemblies
            .SelectMany(a => a.GetTypes())
            .Where(t => !t.IsAbstract && !t.IsInterface)
            .Select(t => new
            {
                Type = t,
                HandlerInterface = t.GetInterfaces()
                    .FirstOrDefault(i =>
                        i.IsGenericType &&
                        i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)
                    )
            })
            .Where(x => x.HandlerInterface != null);

        foreach (var h in handlerTypes)
        {
            var requestType = h.HandlerInterface.GetGenericArguments()[0];
            _handlers[requestType] = h.Type;
        }
    }

    public async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        var requestType = request.GetType();

        if (!_handlers.TryGetValue(requestType, out var handlerType))
            throw new Exception($"Handler for {requestType.Name} not found.");

        // Create handler instance (no DI)
        var handler = ActivatorUtilities.CreateInstance(_provider, handlerType);

        // Find Handle method
        var method = handlerType.GetMethod("Handle");

        if (method == null)
            throw new Exception($"Handle method not found on {handlerType.Name}.");

        // Invoke
        var task = (Task<TResponse>)method.Invoke(handler, new object[] { request, cancellationToken });

        return await task;
    }
}
