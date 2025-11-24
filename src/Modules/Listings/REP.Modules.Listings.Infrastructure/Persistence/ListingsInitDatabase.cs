using Microsoft.EntityFrameworkCore;
using REP.Modules.Listings.Domain.Entities;

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
                new Listing(Guid.NewGuid(), Guid.Parse("28ed6e19-1895-42d3-8b5d-76189d338053"), "Cozy Apartment in Downtown", "A cozy 2-bedroom apartment located in the heart of downtown.", 1500.00m, "123 Main St, Cityville", DateTime.UtcNow),
                new Listing(Guid.NewGuid(), Guid.Parse("28ed6e19-1895-42d3-8b5d-76189d338053"), "Spacious Family Home", "A spacious 4-bedroom family home with a large backyard.", 3000.00m, "456 Oak St, Suburbia", DateTime.UtcNow),
                new Listing(Guid.NewGuid(), Guid.NewGuid(), "Modern Studio Loft", "A modern studio loft with an open floor plan and city views.", 1200.00m, "789 Pine St, Metropolis", DateTime.UtcNow),
                new Listing(Guid.NewGuid(), Guid.NewGuid(), "Charming Cottage", "A charming 3-bedroom cottage in a quiet neighborhood.", 2000.00m, "321 Maple St, Smalltown", DateTime.UtcNow)
            );

            await dbContext.SaveChangesAsync();
        }
    }
}