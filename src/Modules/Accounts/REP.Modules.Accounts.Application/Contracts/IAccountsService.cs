using REP.Modules.Accounts.Application.DTOs;

namespace REP.Modules.Accounts.Application.Contracts;

public interface IAccountsService
{
    // Get account info by id
    Task<AccountDto?> GetAccountByIdAsync(Guid accountId, CancellationToken cancellationToken);
}
