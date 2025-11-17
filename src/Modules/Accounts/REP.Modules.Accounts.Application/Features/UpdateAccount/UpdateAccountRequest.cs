namespace REP.Modules.Accounts.Application.Features.UpdateAccount;

public record UpdateAccountRequest 
(
    int Id,
    string Name,
    string PhoneNumber
);
