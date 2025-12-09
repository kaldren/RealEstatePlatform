namespace REP.Modules.Listings.Application.DTOs;

public record ListingDto
{
    public Guid ListingId { get; init; }
    public Guid AuthorId { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public string Address { get; init; }
    public decimal Price { get; init; }
}
