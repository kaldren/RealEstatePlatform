using Microsoft.EntityFrameworkCore;
using REP.Modules.Reviews.Domain.Entities;
using REP.Shared.DbInit;

namespace REP.Modules.Reviews.Infrastructure.Persistence;

public static class ReviewsinitDatabase
{
    // Insert dummy data
    public static async Task InitializeAsync(ReviewsDbContext dbContext)
    {
        await dbContext.Database.MigrateAsync();

        if (!await dbContext.Reviews.AnyAsync())
        {
            dbContext.Reviews.AddRange(
                // Alice to Kaloyan's listings
                new Review
                {
                    Id = Guid.NewGuid(),
                    ListingId = DbInitializer.Listing__SampleListing1,
                    AuthorId = DbInitializer.Account__Alice,
                    Rating = 5,
                    Comment = "Great place, definitely worth the price!",
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    ListingId = DbInitializer.Listing__SampleListing2,
                    AuthorId = DbInitializer.Account__Alice,
                    Rating = 4,
                    Comment = "Exactly what I'm looking for!",
                },

                // Kaloyan to Alice's listings
                new Review
                {
                    Id = Guid.NewGuid(),
                    ListingId = DbInitializer.Listing__SampleListing3,
                    AuthorId = DbInitializer.Account__Kaloyan,
                    Rating = 5,
                    Comment = "Might consider buying this place.",
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    ListingId = DbInitializer.Listing__SampleListing4,
                    AuthorId = DbInitializer.Account__Kaloyan,
                    Rating = 4,
                    Comment = "I am waiting on a bank response and might proceed with the purchase.",
                });
            await dbContext.SaveChangesAsync();
        }
    }
}
