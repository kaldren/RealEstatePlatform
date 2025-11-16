using REP.Modules.Accounts.Domain.Entities;

namespace REP.Modules.Accounts.Application.Contracts;

public interface IAccountsRepository
{
    // Update user profile
    Task<Account> UpdateUserProfileAsync(Guid userId, string fullName, string phoneNumber, CancellationToken cancellationToken);
}
