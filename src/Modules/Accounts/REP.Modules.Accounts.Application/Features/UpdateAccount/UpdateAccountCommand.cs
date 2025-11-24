using REP.Modules.Accounts.Application.Contracts;
using REP.Shared.Mediator.Contracts;

namespace REP.Modules.Accounts.Application.Features.UpdateAccount;

public record UpdateAccountCommand : IRequest<UpdateAccountResponse>
{
    public string Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, UpdateAccountResponse>
{
    private readonly IAccountsRepository _accountsRepository;

    public UpdateAccountCommandHandler(IAccountsRepository accountsRepository)
    {
        _accountsRepository = accountsRepository;
    }

    public async Task<UpdateAccountResponse> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        var account = await _accountsRepository.UpdateAccountAsync(request, cancellationToken);

        var response = new UpdateAccountResponse(account.Name);

        return response;
    }
}