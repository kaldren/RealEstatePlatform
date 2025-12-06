namespace REP.Shared.DbInit;

public static class DbInitializer
{
    // Accounts
    public readonly static Guid Account__Kaloyan = Guid.Parse("28ed6e19-1895-42d3-8b5d-76189d338053");
    public static readonly Guid Account__Alice = Guid.Parse("39fe7f2a-29a6-43e4-9c6e-8729e4491644");

    // Listings
    public readonly static Guid Listing__SampleListing1 = Guid.CreateVersion7();
    public readonly static Guid Listing__SampleListing2 = Guid.CreateVersion7();
    public readonly static Guid Listing__SampleListing3 = Guid.CreateVersion7();
    public readonly static Guid Listing__SampleListing4 = Guid.CreateVersion7();

    // Reviews
    public readonly static Guid Review__SampleReview1 = Guid.CreateVersion7();
    public readonly static Guid Review__SampleReview2 = Guid.CreateVersion7();
    public readonly static Guid Review__SampleReview3 = Guid.CreateVersion7();
    public readonly static Guid Review__SampleReview4 = Guid.CreateVersion7();
}