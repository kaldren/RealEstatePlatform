using REP.Modules.Listings.Application.Contracts;
using REP.Modules.Listings.Application.Features.CreateListing;
using REP.Modules.Listings.Application.Features.GetSingleListingById;
using REP.Modules.Listings.Application.Features.GetUserListings;
using REP.Shared.Kernel;
using REP.Shared.Mediator.Contracts;

namespace REP.Modules.Listings.Application.Services;

public class ListingsService : IListingsService
{
    private readonly IMediator _mediator;

    public ListingsService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<Result<CreateListingResponse>> CreateListingAsync(CreateListingRequest request)
    {
        return await _mediator.SendAsync(new CreateListingCommand
        {
            AuthorId = request.AuthorId,
            Title = request.Title,
            Description = request.Description,
            Address = request.Address,
            Price = request.Price
        });
    }

    public async Task<Result<GetListingByIdResponse>> GetListingByIdAsync(Guid listingId)
    {
        return await _mediator.SendAsync(new GetSingleListingByIdQuery(listingId));
    }

    public async Task<Result<IEnumerable<AuthorListingResponse>>> GetListingsByAuthorIdAsync(Guid authorId)
    {
        return await _mediator.SendAsync(new GetAuthorListingsQuery(authorId));
    }
}
