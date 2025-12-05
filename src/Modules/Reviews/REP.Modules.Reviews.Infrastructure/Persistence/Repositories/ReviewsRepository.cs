using Microsoft.EntityFrameworkCore;
using REP.Modules.Reviews.Application;
using REP.Modules.Reviews.Domain.Entities;

namespace REP.Modules.Reviews.Infrastructure.Persistence.Repositories;

public class ReviewsRepository : IReviewsRepository
{
    private readonly ReviewsDbContext _reviewsDbContext;

    public ReviewsRepository(ReviewsDbContext reviewsDbContext)
    {
        _reviewsDbContext = reviewsDbContext;
    }

    public async Task<ICollection<Review>> GetReviewsByListingIdAsync(Guid listingId)
    {
        return await _reviewsDbContext.Reviews.Where(r => r.ListingId == listingId).ToListAsync();
    }
}
