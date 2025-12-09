using REP.Shared.Kernel.Abstractions;

namespace REP.Modules.Reviews.Domain.Entities;

public class Review : Entity
{
    public Guid Id { get; private set; }
    public Guid ListingId { get; private set; }
    public Guid AuthorId { get; private set; }
    public int Rating { get; private set; }
    public string Comment { get; private set; } = null!;

    public Review(Guid listingId, Guid authorId, int rating, string comment)
    {
        Id = Guid.NewGuid();
        ListingId = listingId;
        AuthorId = authorId;
        Rating = rating;
        Comment = comment;
        CreatedAt = DateTimeOffset.UtcNow;
    }
}
