using REP.Modules.Accounts.Application.Contracts;
using REP.Modules.Accounts.Application.Features.UpdateAccount;
using REP.Modules.Accounts.Domain.Entities;

namespace REP.Modules.Accounts.Infrastructure.Persistence.Repositories;

public class AccountsRepository : IAccountsRepository
{
    private readonly AccountsDbContext _accountsDbContext;

    public AccountsRepository(AccountsDbContext accountsDbContext)
    {
        _accountsDbContext = accountsDbContext;
    }

    public async Task<Account?> UpdateAccountAsync(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        var account = await _accountsDbContext.Accounts.FindAsync(new object[] { request.Id }, cancellationToken);
        if (account == null) return null;

        account.Name = request.Name;

        await _accountsDbContext.SaveChangesAsync(cancellationToken);
        return account;
    }
}
