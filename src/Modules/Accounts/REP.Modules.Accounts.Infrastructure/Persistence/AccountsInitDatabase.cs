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
                    Id = Guid.Parse("28ed6e19-1895-42d3-8b5d-76189d338053"),
                    Email = "kaloyan.drenski@gmail.com",
                    Name = "Kaloyan Drenski",
                    PhoneNumber = "0888778877"
                },
                new Domain.Entities.Account
                {
                    Id = Guid.NewGuid(),
                    Email = "jane_doe@example.com",
                    Name = "Jane Doe",
                    PhoneNumber = "098-765-4321"
                },
                new Domain.Entities.Account
                {
                    Id = Guid.NewGuid(),
                    Email = "jack_smith@example.com",
                    Name = "Jack Smith",
                    PhoneNumber = "555-555-5555"
                }
            );

            await dbContext.SaveChangesAsync();
        }
    }
}
