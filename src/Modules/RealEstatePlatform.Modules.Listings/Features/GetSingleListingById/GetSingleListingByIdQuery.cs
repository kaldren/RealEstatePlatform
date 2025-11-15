using RealEstatePlatform.Shared.Mediator.Contracts;

namespace RealEstatePlatform.Modules.Listings.Features.GetSingleListingById;

public record GetSingleListingByIdQuery(int Id) : IRequest<ListingDto>;

public record GetSingleListingByIdQueryHandler : IRequestHandler<GetSingleListingByIdQuery, ListingDto>
{
    public async Task<ListingDto> Handle(GetSingleListingByIdQuery request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(new ListingDto(1, "Sample Listing", "This is a sample listing description.", 250000m, "123 Main St, Anytown, USA"));
    }
}