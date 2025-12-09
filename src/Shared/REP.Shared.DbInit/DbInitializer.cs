namespace REP.Shared.DbInit;

public static class DbInitializer
{
    // Accounts
    public readonly static Guid Account__Kaloyan = Guid.Parse("28ed6e19-1895-42d3-8b5d-76189d338053");
    public static readonly Guid Account__Alice = Guid.Parse("39fe7f2a-29a6-43e4-9c6e-8729e4491644");

    // Listings
    public readonly static Guid Listing__SampleListing1 = Guid.Parse("018d3f5e-1a2b-7c4d-8e5f-061728394051");
    public readonly static Guid Listing__SampleListing2 = Guid.Parse("018d3f5e-1a2b-7c4d-8e5f-161728394051");
    public readonly static Guid Listing__SampleListing3 = Guid.Parse("018d3f5e-1a2b-7c4d-8e5f-261728394051");
    public readonly static Guid Listing__SampleListing4 = Guid.Parse("018d3f5e-1a2b-7c4d-8e5f-361728394051");

    // Reviews
    public readonly static Guid Review__SampleReview1 = Guid.Parse("018d3f5e-1a2b-7c4d-8e5f-461728394051");
    public readonly static Guid Review__SampleReview2 = Guid.Parse("018d3f5e-1a2b-7c4d-8e5f-561728394051");
    public readonly static Guid Review__SampleReview3 = Guid.Parse("018d3f5e-1a2b-7c4d-8e5f-661728394051");
    public readonly static Guid Review__SampleReview4 = Guid.Parse("018d3f5e-1a2b-7c4d-8e5f-761728394051");
}