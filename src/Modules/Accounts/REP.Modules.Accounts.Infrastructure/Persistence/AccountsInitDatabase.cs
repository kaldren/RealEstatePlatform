using Microsoft.EntityFrameworkCore;

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
                    Email = "john_doe@example.com",
                    Name = "John Doe",
                    PhoneNumber = "123-456-7890"
                },
                new Domain.Entities.Account
                {
                    Email = "jane_doe@example.com",
                    Name = "Jane Doe",
                    PhoneNumber = "098-765-4321"
                },
                new Domain.Entities.Account
                {
                    Email = "jack_smith@example.com",
                    Name = "Jack Smith",
                    PhoneNumber = "555-555-5555"
                }
            );

            await dbContext.SaveChangesAsync();
        }
    }
}
