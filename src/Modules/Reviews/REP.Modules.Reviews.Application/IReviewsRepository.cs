using REP.Modules.Reviews.Domain.Entities;

namespace REP.Modules.Reviews.Application;

public interface IReviewsRepository
{
    Task<ICollection<Review>> GetReviewsByListingIdAsync(Guid listingId);
}
