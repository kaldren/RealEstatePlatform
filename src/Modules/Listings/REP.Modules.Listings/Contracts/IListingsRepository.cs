using REP.Modules.Listings.Domain.Entities;

namespace REP.Modules.Listings.Application.Contracts;
public interface IListingsRepository
{
    Task<Listing?> GetSingleListing(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Listing>> GetUserListings(Guid userId, CancellationToken cancellationToken = default);
}
