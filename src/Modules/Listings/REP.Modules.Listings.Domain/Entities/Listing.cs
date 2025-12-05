namespace REP.Modules.Listings.Domain.Entities;

public class Listing
{
    public Guid Id { get; set; }
    public Guid OwnerId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Address { get; set; }

    public string ShortUrl { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    public Listing(Guid id, Guid ownerId, string title, string description, decimal price, string address, DateTimeOffset createdAt)
    {
        Id = id;
        OwnerId = ownerId;
        Title = title;
        Description = description;
        Price = price;
        Address = address;
        CreatedAt = createdAt;
    }
}
