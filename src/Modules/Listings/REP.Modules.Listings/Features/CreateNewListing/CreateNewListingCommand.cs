using REP.Modules.Listings.Application.Contracts;
using REP.Shared.Mediator.Contracts;

namespace REP.Modules.Listings.Application.Features.CreateNewListing;

public class CreateNewListingCommand : IRequest<CreateNewListingResponse>
{
    public Guid AuthorId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

public class CreateNewListingCommandHandler : IRequestHandler<CreateNewListingCommand, CreateNewListingResponse>
{
    private readonly IListingsRepository _listingsRepository;

    public CreateNewListingCommandHandler(IListingsRepository listingsRepository)
    {
        _listingsRepository = listingsRepository;
    }

    public async Task<CreateNewListingResponse> Handle(CreateNewListingCommand request, CancellationToken cancellationToken)
    {
        var respone = await _listingsRepository.CreateListingAsync(request.AuthorId, request.Title, request.Description, request.Address, request.Price);

        return new CreateNewListingResponse(respone.Id);
    }
}
