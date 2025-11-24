using Microsoft.EntityFrameworkCore;
using REP.Modules.Listings.Domain.Entities;

namespace REP.Modules.Listings.Infrastructure.Persistence;

public class ListingsDbContext : DbContext
{
    public ListingsDbContext(DbContextOptions<ListingsDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ListingsDbContext).Assembly);

        modelBuilder.Entity<Listing>(builder =>
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.OwnerId).IsRequired();
            builder.Property(e => e.Title).IsRequired().HasMaxLength(200);
            builder.Property(e => e.Description).IsRequired().HasMaxLength(1000);
        });
    }

    // Add entities
    public DbSet<Listing> Listings { get; set; } = null!;
}
