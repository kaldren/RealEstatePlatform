using REP.Shared.Kernel.Abstractions;

namespace REP.Modules.Accounts.Domain.Entities;

public class Account : Entity
{
    public Guid Id { get; private set; }
    public string Email { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public string PhoneNumber { get; private set; } = string.Empty;

    public Account(Guid id, string email, string name, string phoneNumber)
    {
        Id = id;
        Email = email;
        Name = name;
        PhoneNumber = phoneNumber;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }
}
