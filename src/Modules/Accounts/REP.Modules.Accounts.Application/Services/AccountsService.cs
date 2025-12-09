using REP.Modules.Accounts.Application.Contracts;
using REP.Modules.Accounts.Application.DTOs;

namespace REP.Modules.Accounts.Application.Services;

public class AccountsService : IAccountsService
{
    private readonly IAccountsRepository _accountsRepository;

    public AccountsService(IAccountsRepository accountsRepository)
    {
        _accountsRepository = accountsRepository;
    }

    public async Task<AccountDto?> GetAccountByIdAsync(Guid accountId, CancellationToken cancellationToken)
    {
        var account = await _accountsRepository.GetAccountByIdAsync(accountId, cancellationToken);

        return account == null ? null : new AccountDto
        {
            Id = account.Id,
            Email = account.Email,
            Name = account.Name,
            Phone = account.PhoneNumber,
            CreatedAt = account.CreatedAt
        };
    }
}
