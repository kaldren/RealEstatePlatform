using Microsoft.EntityFrameworkCore;
using REP.Modules.Listings.Domain.Entities;

namespace REP.Modules.Listings.Infrastructure.Persistence;

internal class ListingsDbContext : DbContext
{
    public ListingsDbContext(DbContextOptions<ListingsDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ListingsDbContext).Assembly);
    }

    // Add entities
    public DbSet<Listing> Listings { get; set; } = null!;
}
