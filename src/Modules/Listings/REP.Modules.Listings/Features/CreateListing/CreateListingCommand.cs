using REP.Modules.Listings.Application.Contracts;
using REP.Modules.Listings.Application.Features.CreateListing;
using REP.Shared.Mediator.Contracts;

namespace REP.Modules.Listings.Application.Features.CreateListing;

public class CreateListingCommand : IRequest<CreateListingResponse>
{
    public Guid AuthorId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

public class CreateNewListingCommandHandler : IRequestHandler<CreateListingCommand, CreateListingResponse>
{
    private readonly IListingsRepository _listingsRepository;

    public CreateNewListingCommandHandler(IListingsRepository listingsRepository)
    {
        _listingsRepository = listingsRepository;
    }

    public async Task<CreateListingResponse> Handle(CreateListingCommand request, CancellationToken cancellationToken)
    {
        var respone = await _listingsRepository.CreateListingAsync(request.AuthorId, request.Title, request.Description, request.Address, request.Price);

        return new CreateListingResponse(respone.Id);
    }
}
