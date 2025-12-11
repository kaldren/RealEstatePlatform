using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using REP.Modules.Listings.Application.Contracts;
using REP.Modules.Listings.Application.Features.CreateListing;
using REP.Modules.Listings.Application.Features.GetSingleListingById;
using REP.Modules.Listings.Application.Features.GetUserListings;
using REP.Shared.Kernel;

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
            Result<GetListingByIdResponse> result = await listingsService.GetListingByIdAsync(id);

            return result.Success
                ? Results.Ok(result.Value)
                : Results.NotFound();
        });

        /// Get listings by author ID
        /// <param name="authorId">The ID of the author.</param>
        /// <returns>A list of listings by the specified author.</returns>
        /// <remarks>Returns an empty list if the author has no listings.</remarks>
        group.MapGet("/author/{authorId:guid}", static async (Guid authorId, IListingsService listingsService) =>
        {
            Result<IEnumerable<AuthorListingResponse>> result = await listingsService.GetListingsByAuthorIdAsync(authorId);
            
            return result.Success
                ? Results.Ok(result.Value)
                : Results.NotFound();
        });

        /// Create a new listing
        /// <param name="req">The HTTP request containing the listing data.</param>
        /// <returns>The created listing.</returns>
        /// <remarks>Returns a 201 Created response with the location of the new listing.</remarks>
        group.MapPost("/", static async (CreateListingRequest req, IListingsService listingsService, IHttpContextAccessor httpContextAccessor) =>
        {
            Result<CreateListingResponse> result = await listingsService.CreateListingAsync(req);

            return result.Success
                ? Results.Created($"/api/listings/{result.Value.ListingId}", result.Value)
                : Results.BadRequest(result.Error);
        });

        return endpoints;
    }

    public static IServiceCollection AddListingsEndpointsServices(this IServiceCollection services)
    {
        services.AddValidation();
        return services;
    }
}
