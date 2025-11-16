using REP.Modules.Listings.Domain.Entities;

namespace REP.Modules.Listings.Application.Contracts;
public interface IListingsRepository
{
    Task<Listing?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
