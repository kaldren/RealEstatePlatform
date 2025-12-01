using REP.Modules.Reviews.Application;
using REP.Modules.Reviews.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace REP.Modules.Reviews.Infrastructure.Persistence.Repositories;

public class ReviewsRepository : IReviewsRepository
{
    public ReviewsRepository()
    {
        
    }

    public Task<ICollection<Review>> GetReviewsByListingIdAsync(Guid listingId)
    {
        throw new NotImplementedException();
    }
}
