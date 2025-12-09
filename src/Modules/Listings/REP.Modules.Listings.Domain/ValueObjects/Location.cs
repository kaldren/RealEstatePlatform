namespace REP.Modules.Listings.Domain.ValueObjects;

public record Location
{
    public string Country { get; init; }
    public string State { get; init; }
    public string City { get; init; }
    public string ZipCode { get; init; }
    public string AddressLine { get; init; }

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

