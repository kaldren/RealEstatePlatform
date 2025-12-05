using Microsoft.EntityFrameworkCore;
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
                new Domain.Entities.Account
                {
                    Id = DbInitializer.Account__Kaloyan,
                    Email = "kaloyan.drenski@gmail.com",
                    Name = "Kaloyan Drenski",
                    PhoneNumber = "0888778877"
                },
                new Domain.Entities.Account
                {
                    Id = DbInitializer.Account__Alice,
                    Email = "alice_doe@example.com",
                    Name = "Alice Doe",
                    PhoneNumber = "098-765-4321"
                },
                new Domain.Entities.Account
                {
                    Id = Guid.CreateVersion7(),
                    Email = "jack_smith@example.com",
                    Name = "Jack Smith",
                    PhoneNumber = "555-555-5555"
                }
            );

            await dbContext.SaveChangesAsync();
        }
    }
}
