namespace REP.Modules.Listings.Application.Features.CreateListing;

public record CreateListingRequest
{
    public Guid AuthorId { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Address { get; init; } = string.Empty;
    public decimal Price { get; init; }
}