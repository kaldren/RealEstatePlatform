namespace REP.Modules.Reviews.Domain.Entities;

public class Review
{
    public Guid Id { get; set; }
    public Guid ListingId { get; set; }
    public Guid AuthorId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = null!;
    public DateTimeOffset CreatedAt { get; set; }
}
