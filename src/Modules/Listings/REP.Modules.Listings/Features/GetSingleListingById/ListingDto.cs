namespace REP.Modules.Listings.Features.GetSingleListingById;

public record ListingDto(
    int Id,
    string Title,
    string Description,
    decimal Price,
    string Address
);
