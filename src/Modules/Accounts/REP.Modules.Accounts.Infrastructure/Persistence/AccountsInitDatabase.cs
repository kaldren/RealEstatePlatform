using Microsoft.EntityFrameworkCore;
using REP.Modules.Accounts.Domain.Entities;
using REP.Shared.DbInit;

namespace REP.Modules.Accounts.Infrastructure.Persistence;

public static class AccountsInitDatabase
{
    // Insert dummy data
    public static async Task InitializeAsync(AccountsDbContext dbContext)
    {
        await dbContext.Database.MigrateAsync();

        if (!dbContext.Accounts.Any())
        {
            dbContext.Accounts.AddRange(
                new Account(DbInitializer.Account__Kaloyan, "kaloyan.drenski@gmail.com", "Kaloyan Drenski", "0888778877"),
                new Account(DbInitializer.Account__Alice, "alice_doe@example.com", "Alice Doe", "098-765-4321"),
                new Account(Guid.CreateVersion7(), "jack_smith@example.com", "Jack Smith", "555-555-5555")
            );

            await dbContext.SaveChangesAsync();
        }
    }
}
