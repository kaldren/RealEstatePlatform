using REP.Modules.Listings.Application.Features.CreateListing;
using REP.Modules.Listings.Application.Features.GetSingleListingById;
using REP.Modules.Listings.Application.Features.GetUserListings;
using REP.Shared.Kernel;

namespace REP.Modules.Listings.Application.Contracts;

public interface IListingsService
{
    public Task<Result<CreateListingResponse>> CreateListingAsync(CreateListingRequest request);

    public Task<Result<GetListingByIdResponse>> GetListingByIdAsync(Guid listingId);

    public Task<Result<IEnumerable<AuthorListingResponse>>> GetListingsByAuthorIdAsync(Guid authorId);
}
