using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using REP.Shared.Mediator.Contracts;

namespace REP.Modules.Accounts.API;

public static class ReviewsEndpoints
{
    public static IEndpointRouteBuilder MapReviewsEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/listings").RequireAuthorization();

        // Get reviews by listing id
        group.MapGet("{listingId}/reviews", static async (string listingId, IMediator mediator) =>
        {
            // Implementation to get reviews by listing id
            return Results.Ok(new { ListingId = listingId, Reviews = new string[] { "Review1", "Review2" } });
        });

        return endpoints;
    }
}