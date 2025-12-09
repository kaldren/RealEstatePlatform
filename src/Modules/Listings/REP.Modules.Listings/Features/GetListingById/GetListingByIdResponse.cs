namespace REP.Modules.Listings.Application.Features.GetSingleListingById;

public record GetListingByIdResponse(
    Guid Id,
    string Title,
    string Description,
    decimal? Price,
    string? Currency,
    string Location
);
