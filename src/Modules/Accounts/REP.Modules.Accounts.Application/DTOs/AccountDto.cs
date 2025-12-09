namespace REP.Modules.Accounts.Application.DTOs;

public record AccountDto
{
    public Guid Id { get; init; }
    public string Email { get; init; } = null!;
    public string Name { get; init; } = null!;
    public string Phone { get; init; } = null!;
    public DateTimeOffset CreatedAt { get; init; }
}
