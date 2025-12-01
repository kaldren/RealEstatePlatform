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
    }
    
    public DbSet<Review> Reviews { get; set; } = null!;
}
