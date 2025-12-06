using System.Security.Cryptography;

namespace REP.Modules.Listings.Domain.Entities;

public class Listing
{
    public Guid Id { get; set; }
    public Guid OwnerId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Price Price { get; set; }
    public Location Location { get; set; }

    public string ShortUrl { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    private Listing() { }

    public Listing(
        Guid id,
        Guid ownerId,
        string title,
        string description,
        Price price,
        Location location,
        DateTimeOffset createdAt)
    {
        if (id.Version != 7)
            throw new ArgumentException("Id must be V7 UUID.");

        Id = id;
        OwnerId = ownerId;
        Title = title;
        Description = description;
        Price = price;
        Location = location;
        CreatedAt = createdAt;
        ShortUrl = GenerateShortUrl(title);
    }


    private static string GenerateShortUrl(string title)
    {
        // The short url has to contain the title of the listing for SEO purposes + a random string to ensure uniqueness.
        return $"{title.ToLower().Replace(" ", "-")}-{RandomNumberGenerator.GetInt32(1, int.MaxValue)}";
    }
}

public record class Location
{
    public string Country { get; private set; }
    public string State { get; private set; }
    public string City { get; private set; }
    public string ZipCode { get; private set; }
    public string AddressLine { get; private set; }

    private Location() { }  // EF uses this

    public Location(string country, string state, string city, string zip, string address)
    {
        Country = country;
        State = state;
        City = city;
        ZipCode = zip;
        AddressLine = address;
    }

    public override string ToString()
        => $"{AddressLine}, {City}, {State}, {ZipCode}, {Country}";
}


public record class Price
{
    public decimal? Amount { get; init; }
    public Currency? Currency { get; init; }

    private Price() { }

    public Price(decimal? amount, Currency? currency)
    {
        // if price is null then you cannot have currency
        if (amount is null && currency is not null)
        {
            throw new ArgumentException("If price is null then currency must be null as well.");
        }

        // if price is not null then you must have currency
        if (amount is not null && currency is null)
        {
            throw new ArgumentException("If price is not null then currency must be provided.");
        }

        // if price is less than zero
        if (amount is not null && amount < 0)
        {
            throw new ArgumentException("Price cannot be less than zero.");
        }

        // Price cannot be larger than 1 billion
        if (amount is not null && amount > 1_000_000_000)
        {
            throw new ArgumentException("Price cannot be larger than 1 billion.");
        }

        // if currency code is empty
        if (currency is not null && string.IsNullOrWhiteSpace(currency.Code))
        {
            throw new ArgumentException("Currency code cannot be empty.");
        }

        // if currency symbol is empty
        if (currency is not null && string.IsNullOrWhiteSpace(currency.Symbol))
        {
            throw new ArgumentException("Currency symbol cannot be empty.");
        }

        Amount = amount;
        Currency = currency;
    }
}
public record class Currency
{
    public string Code { get; private set; }
    public string Symbol { get; private set; }

    private Currency() { }  // EF uses this

    public Currency(string code, string symbol)
    {
        Code = code;
        Symbol = symbol;
    }
}

