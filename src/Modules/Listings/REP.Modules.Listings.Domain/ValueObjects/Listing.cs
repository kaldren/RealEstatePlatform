using REP.Modules.Listings.Domain.Events;
using REP.Shared.Kernel.Abstractions;
using System.Security.Cryptography;

namespace REP.Modules.Listings.Domain.ValueObjects;

public class Listing : Entity
{
    public Guid Id { get; private set; }
    public Guid AuthorId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public Price Price { get; private set; }
    public Location Location { get; private set; }
    public string ShortUrl { get; private set; }

    private Listing() { } // EF uses this

    public Listing(
        Guid id,
        Guid authorId,
        string title,
        string description,
        Price price,
        Location location,
        DateTimeOffset createdAt)
    {
        Id = id;
        AuthorId = authorId;
        Title = title;
        Description = description;
        Price = price;
        Location = location;
        CreatedAt = createdAt;
        ShortUrl = GenerateShortUrl(title, location.City, location.State);

        AddDomainEvent(new ListingCreatedDomainEvent(ListingId: id, AuthorId: authorId, Title: title, Description: description, Amount: price?.Amount, CurrencyCode: price?.Currency?.Code, Address: location.AddressLine));
    }

    private static string GenerateShortUrl(string title, string city, string state)
    {
        // The short url has to contain the title of the listing for SEO purposes + a random string to ensure uniqueness.
        return $"{title.ToLower().Replace(" ", "-")}-{city.ToLower()}-{state.ToLower()}-{RandomNumberGenerator.GetInt32(1000, 1000000)}";
    }
}
