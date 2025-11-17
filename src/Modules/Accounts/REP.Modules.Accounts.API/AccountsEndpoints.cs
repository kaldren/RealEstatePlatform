using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using REP.Modules.Accounts.Application.Features.UpdateAccount;
using REP.Shared.Mediator.Contracts;

namespace REP.Modules.Accounts.API;

public static class AccountsEndpoints
{
    public static IEndpointRouteBuilder MapAccountsEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/accounts");

        // Update user profile
        group.MapPut("/profile", static async (UpdateAccountRequest request, IMediator mediator) =>
        {
            var result = await mediator.SendAsync(new UpdateAccountCommand()
            {
                Id = request.Id,
                Name = request.Name,
                PhoneNumber = request.PhoneNumber
            });

            return Results.Ok(result);
        });

        return endpoints;
    }
}
