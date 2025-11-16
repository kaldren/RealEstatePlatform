using REP.Modules.Accounts.Application.Contracts;
using REP.Modules.Accounts.Domain.Entities;

namespace REP.Modules.Accounts.Infrastructure.Persistence.Repositories;

public class AccountsRepository : IAccountsRepository
{
    public AccountsRepository()
    {
        
    }

    public async Task<Account> UpdateUserProfileAsync(Guid userId, string fullName, string phoneNumber, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
