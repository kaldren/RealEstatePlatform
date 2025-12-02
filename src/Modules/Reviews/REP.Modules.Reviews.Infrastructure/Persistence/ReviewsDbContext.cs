using Microsoft.EntityFrameworkCore;
using REP.Modules.Reviews.Domain.Entities;

namespace REP.Modules.Reviews.Infrastructure.Persistence;

public class ReviewsDbContext : DbContext
{
    public ReviewsDbContext(DbContextOptions<ReviewsDbContext> options)
    : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReviewsDbContext).Assembly);

        modelBuilder.Entity<Review>(builder =>
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.ListingId).IsRequired();
            builder.Property(r => r.AuthorId).IsRequired();
            builder.Property(r => r.Comment).IsRequired().HasMaxLength(1000);
            builder.Property(r => r.Rating).IsRequired();
            builder.Property(r => r.CreatedAt).IsRequired();

            // Non-clustered index on ListingId for faster lookups
            builder.HasIndex(r => r.ListingId).IsClustered(false);
        });
    }
    
    public DbSet<Review> Reviews { get; set; } = null!;
}
