namespace REP.Shared.DbInit;

public static class DbInitializer
{
    // Accounts
    public readonly static Guid Account__Kaloyan = Guid.Parse("28ed6e19-1895-42d3-8b5d-76189d338053");
    public static readonly Guid Account__Alice = Guid.Parse("39fe7f2a-29a6-43e4-9c6e-8729e4491644");

    // Listings
    public readonly static Guid Listing__SampleListing1 = Guid.Parse("a1b2c3d4-e5f6-4789-9012-abcdefabcdef");
    public readonly static Guid Listing__SampleListing2 = Guid.Parse("b2c3d4e5-f678-4901-2345-bcdefabcdef0");
    public readonly static Guid Listing__SampleListing3 = Guid.Parse("c3d4e5f6-7890-5123-4567-cdefabcdef01");
    public readonly static Guid Listing__SampleListing4 = Guid.Parse("d4e5f678-9012-3456-5678-defabcdef012");

    // Reviews
    public readonly static Guid Review__SampleReview1 = Guid.Parse("d4e5f678-9012-3456-5678-defabcdef012");
    public readonly static Guid Review__SampleReview2 = Guid.Parse("e5f67890-1234-4567-6789-efabcdef0123");
    public readonly static Guid Review__SampleReview3 = Guid.Parse("f6789012-2345-5678-7890-fabcdef01234");
}