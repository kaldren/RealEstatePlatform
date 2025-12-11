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

        /// <summary>Get listing by ID</summary>
        /// <param name="id">The ID of the listing.</param>
        /// <returns><b>200 OK</b> with the listing details or <b>404 Not Found</b> if not found.</returns>
        /// <response code="200">Listing found</response>
        /// <response code="404">Listing not found</response>
        group.MapGet("/{id:guid}", static async (Guid id, IListingsService listingsService) =>
        {
            Result<GetListingByIdResponse> result = await listingsService.GetListingByIdAsync(id);

            return result.Success
                ? Results.Ok(result.Value)
                : Results.NotFound();
        });

        /// <summary>Get listings by author ID</summary>
        /// <param name="authorId">The ID of the author.</param>
        /// <returns><b>200 OK</b> with a list of listings by the specified author or <b>404 Not Found</b> if none exist.</returns>
        /// <response code="200">Listings found</response>
        /// <response code="404">No listings found</response>
        group.MapGet("/author/{authorId:guid}", static async (Guid authorId, IListingsService listingsService) =>
        {
            Result<IEnumerable<AuthorListingResponse>> result = await listingsService.GetListingsByAuthorIdAsync(authorId);
            
            return result.Success
                ? Results.Ok(result.Value)
                : Results.NotFound();
        });

        /// <summary>Create a new listing</summary>
        /// <param name="req">The HTTP request containing the listing data.</param>
        /// <returns><b>201 Created</b> with the location of the new listing or <b>400 Bad Request</b> if the request is invalid.</returns>
        /// <response code="201">Listing created</response>
        /// <response code="400">Bad request</response>
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
