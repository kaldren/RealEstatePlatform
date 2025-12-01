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
        var group = endpoints.MapGroup("/api/accounts").RequireAuthorization();

        group.MapPost("settings", static async (UserSettings request, IMediator mediator, IHttpContextAccessor httpContextAccessor) =>
        {
            // Get current user from jwt
            var userId = httpContextAccessor.HttpContext.User.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier").Value;

            var result = await mediator.SendAsync(new UpdateAccountCommand()
            {
                Id = userId,
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