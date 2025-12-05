using REP.Modules.Reviews.Domain.Entities;

namespace REP.Modules.Reviews.Application.Contracts;

public interface IReviewsRepository
{
    Task<ICollection<Review>> GetListingReviews(Guid listingId);
}
