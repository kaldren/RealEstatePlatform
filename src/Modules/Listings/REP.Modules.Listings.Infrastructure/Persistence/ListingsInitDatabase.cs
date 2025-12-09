using Microsoft.EntityFrameworkCore;
using REP.Modules.Listings.Domain.Entities;
using REP.Modules.Listings.Domain.ValueObjects;
using REP.Shared.DbInit;

namespace REP.Modules.Listings.Infrastructure.Persistence;

public static class ListingsInitDatabase
{
    // Insert dummy data
    public static async Task InitializeAsync(ListingsDbContext dbContext)
    {
        await dbContext.Database.MigrateAsync();

        if (!dbContext.Listings.Any())
        {
            dbContext.Listings.AddRange(
                new Listing(DbInitializer.Listing__SampleListing1, DbInitializer.Account__Kaloyan, "Cozy Apartment in Downtown", "A cozy 2-bedroom apartment located in the heart of downtown.", new Price(1500.00m, new Currency("USD", "$")), new Location("USA", "CA", "Cityville", "12345", "123 Main St"), DateTime.UtcNow),
                new Listing(DbInitializer.Listing__SampleListing2, DbInitializer.Account__Kaloyan, "Spacious Family Home", "A spacious 4-bedroom family home with a large backyard.", new Price(3000.00m, new Currency("USD", "$")), new Location("USA", "CA", "Suburbia", "12345", "456 Oak St"), DateTime.UtcNow),
                new Listing(DbInitializer.Listing__SampleListing3, DbInitializer.Account__Alice, "Modern Studio Loft", "A modern studio loft with an open floor plan and city views.", new Price(1200.00m, new Currency("USD", "$")), new Location("USA", "NY", "Metropolis", "12345", "789 Pine St"), DateTime.UtcNow),
                new Listing(DbInitializer.Listing__SampleListing4, DbInitializer.Account__Alice, "Charming Cottage", "A charming 3-bedroom cottage in a quiet neighborhood.", new Price(2000.00m, new Currency("USD", "$")), new Location("USA", "TX", "Smalltown", "12345", "321 Maple St"), DateTime.UtcNow)
            );

            await dbContext.SaveChangesAsync();
        }
    }
}