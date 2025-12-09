namespace REP.Modules.Reviews.Application.Features.GetListingReviews;

public record GetListingReviewsResponse(Guid Id, Guid ListingId, Guid AuthorId, string Author, int Rating, string Comment, DateTimeOffset CreatedAt);