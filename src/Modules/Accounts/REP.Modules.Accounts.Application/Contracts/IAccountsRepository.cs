namespace REP.Modules.Accounts.Application.Contracts;

public interface IAccountsRepository
{
    // Update user profile
    Task UpdateUserProfileAsync(Guid userId, string fullName, string phoneNumber, CancellationToken cancellationToken);
}
