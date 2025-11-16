using Microsoft.EntityFrameworkCore;
using REP.Modules.Listings.Domain.Entities;

namespace REP.Modules.Listings.Infrastructure.Persistence;

public class SetupDatabase
{
    // Insert dummy data
    public static async Task InitializeAsync(ListingsDbContext dbContext)
    {
        await dbContext.Database.MigrateAsync();

        if (!dbContext.Listings.Any())
        {
            dbContext.Listings.AddRange(
                new Listing
                {
                    Title = "Cozy Apartment in Downtown",
                    Description = "A cozy 2-bedroom apartment located in the heart of the city.",
                    Price = 1500.00m,
                    Address = "123 Main St, Cityville",
                    CreatedAt = DateTime.UtcNow
                },
                new Listing
                {
                    Title = "Spacious Suburban Home",
                    Description = "A spacious 4-bedroom home with a large backyard.",
                    Price = 3000.00m,
                    Address = "456 Oak Dr, Suburbia",
                    CreatedAt = DateTime.UtcNow
                },
                new Listing
                {
                    Title = "Modern Condo with City View",
                    Description = "A modern 3-bedroom condo offering stunning views of the city skyline.",
                    Price = 2500.00m,
                    Address = "789 Pine St, Metropolis",
                    CreatedAt = DateTime.UtcNow
                },
                new Listing
                {
                    Title = "Charming Cottage by the Lake",
                    Description = "A charming 2-bedroom cottage located near the lake.",
                    Price = 1800.00m,
                    Address = "321 Lakeview Rd, Lakeside",
                    CreatedAt = DateTime.UtcNow
                }
            );

            await dbContext.SaveChangesAsync();
        }
    }
}