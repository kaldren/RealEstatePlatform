using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using REP.Modules.Listings.Application.Features.GetSingleListingById;
using REP.Modules.Listings.Application.Features.GetUserListings;
using REP.Shared.Mediator.Contracts;

namespace REP.Modules.Listings.API;

public static class ListingsEndpoints
{
    public static IEndpointRouteBuilder MapListingsEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/listings");

        // Get listing by id
        group.MapGet("/{id:guid}", static async (Guid id, IMediator mediator) =>
        {
            // Inject Mediator
            var result = await mediator.SendAsync(new GetSingleListingByIdQuery(id));
            return result is null ? Results.NotFound() : Results.Ok(result);
        });

        // Get all listings of a user
        group.MapGet("/user/{userId:guid}", static async (Guid userId, IMediator mediator) =>
        {
            // Inject Mediator
            var result = await mediator.SendAsync(new GetUserListingsQuery(userId));
            return Results.Ok(result);
        });

        return endpoints;
    }
}
