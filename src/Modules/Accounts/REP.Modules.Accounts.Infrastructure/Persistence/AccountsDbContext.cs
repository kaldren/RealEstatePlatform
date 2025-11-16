using Microsoft.EntityFrameworkCore;
using REP.Modules.Accounts.Domain.Entities;
using System.Reflection;

namespace REP.Modules.Accounts.Infrastructure.Persistence;

public class AccountsDbContext : DbContext
{
    public AccountsDbContext(DbContextOptions<AccountsDbContext> options)
    : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountsDbContext).Assembly);
    }

    // Add entities
    public DbSet<Account> Accounts { get; set; } = null!;
}
