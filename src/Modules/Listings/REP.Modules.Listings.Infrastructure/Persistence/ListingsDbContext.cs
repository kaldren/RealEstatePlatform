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
            builder.Property(e => e.ShortUrl).IsRequired();
            builder.Property(e => e.CreatedAt).IsRequired();

            // ----- PRICE -----
            builder.OwnsOne(x => x.Price, price =>
            {
                price.Property(p => p.Amount)
                    .HasColumnName("PriceAmount")
                    .HasPrecision(18, 2);

                price.OwnsOne(p => p.Currency!, currency =>
                {
                    currency.Property(c => c.Code)
                        .HasColumnName("PriceCurrencyCode");

                    currency.Property(c => c.Symbol)
                        .HasColumnName("PriceCurrencySymbol");
                });
            });

            // ----- LOCATION -----
            builder.OwnsOne(x => x.Location, location =>
            {
                location.Property(p => p.Country)
                    .HasColumnName("Country");

                location.Property(p => p.State)
                    .HasColumnName("State");

                location.Property(p => p.City)
                    .HasColumnName("City");

                location.Property(p => p.ZipCode)
                    .HasColumnName("ZipCode");

                location.Property(p => p.AddressLine)
                    .HasColumnName("AddressLine");
            });

            // Make ShortUrl unique
            builder.HasIndex(e => e.ShortUrl).IsUnique();
        });
    }

    // Add entities
    public DbSet<Listing> Listings { get; set; } = null!;
}
