namespace REP.Modules.Listings.Application.Features.GetSingleListingById;

public record ListingDto(
    Guid Id,
    string Title,
    string Description,
    decimal Price,
    string Address
);
