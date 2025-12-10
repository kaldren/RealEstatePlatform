using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using REP.Modules.Listings.Application.Contracts;
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

        /// Get listing by ID
        /// <param name="id">The ID of the listing.</param>
        /// <returns>The listing with the specified ID, or NotFound if it doesn't exist.</returns>
        /// <remarks>Returns a 404 Not Found response if the listing is not found.</remarks>
        group.MapGet("/{id:guid}", static async (Guid id, IListingsService listingsService) =>
        {
            GetListingByIdResponse? result = await listingsService.GetListingByIdAsync(id);
            return result is null ? Results.NotFound() : Results.Ok(result);
        });

        /// Get listings by author ID
        /// <param name="authorId">The ID of the author.</param>
        /// <returns>A list of listings by the specified author.</returns>
        /// <remarks>Returns an empty list if the author has no listings.</remarks>
        group.MapGet("/author/{authorId:guid}", static async (Guid authorId, IListingsService listingsService) =>
        {
            var result = await listingsService.GetListingsByAuthorIdAsync(authorId);
            return Results.Ok(result);
        });

        /// Create a new listing
        /// <param name="req">The HTTP request containing the listing data.</param>
        /// <returns>The created listing.</returns>
        /// <remarks>Returns a 201 Created response with the location of the new listing.</remarks>
        group.MapPost("/", static async (HttpRequest req, IListingsService listingsService, IHttpContextAccessor httpContextAccessor) =>
        {
            var userId = httpContextAccessor.HttpContext?.User?.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value;

            if (userId is null)
            {
                return Results.Unauthorized();
            }

            var listingRequest = await req.ReadFromJsonAsync<CreateListingRequest>();

            if (listingRequest is null)
            {
                return Results.BadRequest("Invalid listing data.");
            }

            var newListing = await listingsService.CreateListingAsync(listingRequest);

            return Results.Created($"/api/listings/{newListing.ListingId}", newListing);
        });

        return endpoints;
    }
}
