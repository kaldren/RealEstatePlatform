namespace REP.Modules.Listings.Application.Features.GetUserListings;

public record AuthorListingResponse(
    Guid Id,
    Guid OwnerId,
    string Title,
    string Description,
    decimal? Price,
    string? Currency,
    string Address,
    DateTimeOffset CreatedAt
);