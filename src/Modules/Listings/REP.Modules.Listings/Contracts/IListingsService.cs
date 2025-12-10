using REP.Modules.Listings.Application.Features.CreateListing;
using REP.Modules.Listings.Application.Features.GetSingleListingById;
using REP.Modules.Listings.Application.Features.GetUserListings;

namespace REP.Modules.Listings.Application.Contracts;

public interface IListingsService
{
    public Task<CreateListingResponse> CreateListingAsync(CreateListingRequest request);

    public Task<GetListingByIdResponse?> GetListingByIdAsync(Guid listingId);

    public Task<IEnumerable<AuthorListingResponse>> GetListingsByAuthorIdAsync(Guid authorId);
}
