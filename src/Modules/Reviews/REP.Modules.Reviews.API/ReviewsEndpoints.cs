using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using REP.Modules.Reviews.Application.Features.GetListingReviews;
using REP.Shared.Mediator.Contracts;

namespace REP.Modules.Accounts.API;

public static class ReviewsEndpoints
{
    public static IEndpointRouteBuilder MapReviewsEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/api/listings").RequireAuthorization();

        group.MapGet("{listingId}/reviews", static async (string listingId, IMediator mediator) =>
        {
            var result = await mediator.SendAsync(new GetListingReviewsQuery(Guid.Parse(listingId)));

            return Results.Ok(result);
        });

        return endpoints;
    }
}