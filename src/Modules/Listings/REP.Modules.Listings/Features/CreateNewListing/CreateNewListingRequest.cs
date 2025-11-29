namespace REP.Modules.Listings.Application.Features.CreateNewListing;

public record CreateNewListingRequest
{
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Address { get; init; } = string.Empty;
    public decimal Price { get; init; }
}