using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using REP.Modules.Listings.Application.Features.CreateListing;
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
            var result = await mediator.SendAsync(new GetSingleListingByIdQuery(id));
            return result is null ? Results.NotFound() : Results.Ok(result);
        });

        // Get all listings of a given author
        group.MapGet("/author/{authorId:guid}", static async (Guid authorId, IMediator mediator) =>
        {
            var result = await mediator.SendAsync(new GetAuthorListingsQuery(authorId));
            return Results.Ok(result);
        });

        // Create new listing
        group.MapPost("/", static async (HttpRequest req, IMediator mediator, IHttpContextAccessor httpContextAccessor) =>
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier").Value;

            if (userId is null)
            {
                return Results.Unauthorized();
            }

            var listingRequest = await req.ReadFromJsonAsync<CreateListingRequest>();
            var listingCommand = new CreateListingCommand
            {
                AuthorId = Guid.Parse(userId),
                Title = listingRequest.Title,
                Description = listingRequest.Description,
                Address = listingRequest.Address,
                Price = listingRequest.Price
            };


            var result = await mediator.SendAsync(listingCommand);
            return Results.Created($"/api/listings/{result.ListingId}", result);
        });

        return endpoints;
    }
}
