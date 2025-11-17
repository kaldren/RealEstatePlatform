using REP.Modules.Accounts.Application.Contracts;
using REP.Modules.Accounts.Application.Features.UpdateAccount;
using REP.Modules.Accounts.Domain.Entities;

namespace REP.Modules.Accounts.Infrastructure.Persistence.Repositories;

public class AccountsRepository : IAccountsRepository
{
    private readonly IAccountsRepository _accountsRepository;

    public AccountsRepository(IAccountsRepository accountsRepository)
    {
        _accountsRepository = accountsRepository;
    }

    public Task<Account> UpdateAccountAsync(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        return _accountsRepository.UpdateAccountAsync(request, cancellationToken);
    }
}
