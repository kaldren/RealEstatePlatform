using Microsoft.EntityFrameworkCore;
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

    public async Task<Listing?> AddListingAsync(Guid AuthorId, string Title, string Description, string Address, decimal Price, CancellationToken cancellationToken = default)
    {
        var listing = new Listing(
            Guid.NewGuid(), // id
            AuthorId,       // ownerId
            Title,          // title
            Description,    // description
            Price,          // price
            Address,   // address (default value, update as needed)
            DateTimeOffset.UtcNow // createdAt
        );

        _db.Listings.Add(listing);
        return await _db.SaveChangesAsync(cancellationToken)
            .ContinueWith(_ => listing, cancellationToken);
    }

    public async Task<Listing?> GetSingleListingAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _db.Listings.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<IEnumerable<Listing>> GetUserListingsAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var listings = _db.Listings.Where(listing => listing.OwnerId == userId);
        return await listings.ToListAsync(cancellationToken);
    }
}
