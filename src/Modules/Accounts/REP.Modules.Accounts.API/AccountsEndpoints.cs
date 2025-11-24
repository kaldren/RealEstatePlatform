using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using REP.Modules.Accounts.Application.Features.UpdateAccount;
using REP.Shared.Mediator.Contracts;
using System.Security.Claims;

namespace REP.Modules.Accounts.API;

public static class AccountsEndpoints
{
    public static IEndpointRouteBuilder MapAccountsEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/accounts");

        group.MapPost("settings", [Authorize] static async (UserSettings request, IMediator mediator, IHttpContextAccessor httpContextAccessor) =>
        {
            // Get current user from jwt

            var result = await mediator.SendAsync(new UpdateAccountCommand()
            {

                Name = request.Name,
            });

            return Results.Ok(result);
        });

        return endpoints;
    }
}

class UserSettings
{
    public string Name { get; set; } = string.Empty;
}