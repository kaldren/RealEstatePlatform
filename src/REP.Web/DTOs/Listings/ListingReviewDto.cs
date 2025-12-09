namespace REP.Web.DTOs.Listings;

public record ListingReviewDto(
    Guid Id,
    Guid ListingId,
    Guid AuthorId,
    string Author,
    int Rating,
    string Comment,
    DateTimeOffset CreatedAt
);
