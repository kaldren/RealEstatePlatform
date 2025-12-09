using Microsoft.EntityFrameworkCore;
using REP.Modules.Reviews.Domain.Entities;
using REP.Shared.DbInit;

namespace REP.Modules.Reviews.Infrastructure.Persistence;

public static class ReviewsInitDatabase
{
    // Insert dummy data
    public static async Task InitializeAsync(ReviewsDbContext dbContext)
    {
        await dbContext.Database.MigrateAsync();

        if (!await dbContext.Reviews.AnyAsync())
        {
            dbContext.Reviews.AddRange(
                // Alice to Kaloyan's listings
                new Review(listingId: DbInitializer.Listing__SampleListing1,
                           authorId: DbInitializer.Account__Alice,
                           rating: 5,
                           comment: "Great place, enjoyed my stay!"),

                new Review(listingId: DbInitializer.Listing__SampleListing2,
                           authorId: DbInitializer.Account__Alice,
                           rating: 4,
                           comment: "Exactly what I'm looking for!"),

                // Kaloyan to Alice's listings
                new Review(listingId: DbInitializer.Listing__SampleListing3,
                           authorId: DbInitializer.Account__Kaloyan,
                           rating: 5,
                           comment: "Might consider buying this place."),

                new Review(listingId: DbInitializer.Listing__SampleListing4,
                           authorId: DbInitializer.Account__Kaloyan,
                           rating: 4,
                           comment: "I am waiting on a bank response and might proceed with the purchase."));
            await dbContext.SaveChangesAsync();
        }
    }
}
