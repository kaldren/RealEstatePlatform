using Microsoft.EntityFrameworkCore;

namespace REP.Modules.Accounts.Infrastructure.Persistence;

public static class SetupDatabase
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
                    Email = "john_doe@example.com"
                },
                new Domain.Entities.Account
                {
                    Email = "jane_doe@example.com"
                },
                new Domain.Entities.Account
                {
                    Email = "jack_smith@example.com"
                }
            );

            await dbContext.SaveChangesAsync();
        }
    }
}
