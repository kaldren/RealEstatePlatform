using REP.Modules.Listings.Application.Contracts;
using REP.Shared.Mediator.Contracts;

namespace REP.Modules.Listings.Application.Features.GetSingleListingById;

public record GetSingleListingByIdQuery(Guid Id) : IRequest<GetListingByIdResponse?>;

public record GetSingleListingByIdQueryHandler : IRequestHandler<GetSingleListingByIdQuery, GetListingByIdResponse?>
{
    private readonly IListingsRepository _repository;

    public GetSingleListingByIdQueryHandler(IListingsRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetListingByIdResponse?> Handle(GetSingleListingByIdQuery request, CancellationToken cancellationToken)
    {
        var listing = await _repository.GetSingleListing(request.Id, cancellationToken);

        return listing is not null
            ? new GetListingByIdResponse(listing.Id, listing.Title, listing.Description, listing.Price, listing.Address)
            : null;
    }
}