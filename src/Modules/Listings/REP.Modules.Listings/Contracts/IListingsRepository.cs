using REP.Modules.Listings.Domain.Entities;

namespace REP.Modules.Listings.Application.Contracts;
public interface IListingsRepository
{
    Task<Listing?> GetSingleListingAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Listing>> GetUserListingsAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<Listing?> CreateListingAsync(Guid AuthorId, string Title, string Description, string Address, decimal Price, CancellationToken cancellationToken = default);
}
