using REP.Modules.Listings.Application.Contracts;
using REP.Modules.Listings.Domain.Entities;

namespace REP.Modules.Listings.Infrastructure.Persistence.Repositories;

public class ListingsRepository : IListingsRepository
{
    private readonly ListingsDbContext _db;

    public ListingsRepository(ListingsDbContext db)
    {
        _db = db;
    }

    public async Task<Listing?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _db.Listings.FindAsync(new object[] { id }, cancellationToken);
    }
}
