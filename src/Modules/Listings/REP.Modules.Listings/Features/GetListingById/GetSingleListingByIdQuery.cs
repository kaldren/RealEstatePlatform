using REP.Modules.Listings.Application.Contracts;
using REP.Shared.Kernel;
using REP.Shared.Mediator.Contracts;

namespace REP.Modules.Listings.Application.Features.GetSingleListingById;

public record GetSingleListingByIdQuery(Guid Id) : IRequest<Result<GetListingByIdResponse>>;

public record GetSingleListingByIdQueryHandler : IRequestHandler<GetSingleListingByIdQuery, Result<GetListingByIdResponse>>
{
    private readonly IListingsRepository _repository;

    public GetSingleListingByIdQueryHandler(IListingsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetListingByIdResponse>> Handle(GetSingleListingByIdQuery request, CancellationToken cancellationToken)
    {
        var listing = await _repository.GetSingleListingAsync(request.Id, cancellationToken);

        return listing is not null
            ? Result<GetListingByIdResponse>.Ok(new GetListingByIdResponse(listing.Id, listing.Title, listing.Description, listing.Price.Amount, listing.Price.Currency?.Code, listing.Location.ToString()))
            : Result<GetListingByIdResponse>.Fail("Listing not found");
    }
}