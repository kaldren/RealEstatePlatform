using REP.Modules.Accounts.Application.Features.UpdateAccount;
using REP.Modules.Accounts.Domain.Entities;

namespace REP.Modules.Accounts.Application.Contracts;

public interface IAccountsRepository
{
    // Update user profile
    Task<Account?> UpdateAccountAsync(UpdateAccountCommand request, CancellationToken cancellationToken);

    // Get account by id
    Task<Account?> GetAccountByIdAsync(Guid id, CancellationToken cancellationToken);
}
