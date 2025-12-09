using REP.Modules.Listings.Application.Contracts;
using REP.Modules.Listings.Application.Features.CreateListing;
using REP.Modules.Listings.Application.Features.GetSingleListingById;
using REP.Shared.Mediator.Contracts;

namespace REP.Modules.Listings.Application.Services;

public class ListingsService : IListingsService
{
    private readonly IMediator _mediator;

    public ListingsService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task<CreateListingResponse> CreateListingAsync(CreateListingRequest request)
    {
        return _mediator.SendAsync(new CreateListingCommand
        {
            AuthorId = request.AuthorId,
            Title = request.Title,
            Description = request.Description,
            Address = request.Address,
            Price = request.Price
        });
    }

    public Task<GetListingByIdResponse?> GetListingByIdAsync(Guid listingId)
    {
        return _mediator.SendAsync(new GetSingleListingByIdQuery(listingId));
    }
}
