using REP.Shared.Mediator.Contracts;

namespace REP.Modules.Listings.Application.Features.GetSingleListingById;

public record GetSingleListingByIdQuery(Guid Id) : IRequest<ListingDto>;

public record GetSingleListingByIdQueryHandler : IRequestHandler<GetSingleListingByIdQuery, ListingDto>
{
    public async Task<ListingDto> Handle(GetSingleListingByIdQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(new ListingDto(Guid.NewGuid(), "Sample Listing", "This is a sample listing description.", 250000m, "123 Main St, Anytown, USA"));
    }
}