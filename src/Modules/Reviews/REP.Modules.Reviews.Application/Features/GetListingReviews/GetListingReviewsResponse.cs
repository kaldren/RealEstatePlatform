namespace REP.Modules.Reviews.Application.Features.GetListingReviews;

public record GetListingReviewsResponse(Guid Id, Guid ListingId, int Rating, string Comment, DateTimeOffset CreatedAt);