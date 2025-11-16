namespace REP.Modules.Listings.Domain.Entities;

public class Listing
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string Address { get; set; } = null!;
}
