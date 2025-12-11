using REP.Modules.Listings.Application.Contracts;
using REP.Modules.Listings.Application.Features.CreateListing;
using REP.Shared.Kernel;
using REP.Shared.Mediator.Contracts;

namespace REP.Modules.Listings.Application.Features.CreateListing;

public class CreateListingCommand : IRequest<Result<CreateListingResponse>>
{
    public Guid AuthorId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

public class CreateNewListingCommandHandler : IRequestHandler<CreateListingCommand, Result<CreateListingResponse>>
{
    private readonly IListingsRepository _listingsRepository;

    public CreateNewListingCommandHandler(IListingsRepository listingsRepository)
    {
        _listingsRepository = listingsRepository;
    }

    public async Task<Result<CreateListingResponse>> Handle(CreateListingCommand request, CancellationToken cancellationToken)
    {
        var respone = await _listingsRepository.CreateListingAsync(request.AuthorId, request.Title, request.Description, request.Address, request.Price);

        if (respone == null)
            return Result<CreateListingResponse>.Fail("Failed to create listing");
        else
            return Result<CreateListingResponse>.Ok(new CreateListingResponse(respone.Id));
    }
}
