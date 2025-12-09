using REP.Modules.Listings.Application.Contracts;
using REP.Shared.Mediator.Contracts;

namespace REP.Modules.Listings.Application.Features.GetUserListings;

public record GetAuthorListingsQuery(Guid UserId) : IRequest<IEnumerable<UserListingResponse>?>;

public class GetUserListingsQueryHandler : IRequestHandler<GetAuthorListingsQuery, IEnumerable<UserListingResponse>?>
{
    private readonly IListingsRepository _listingsRepository;

    public GetUserListingsQueryHandler(IListingsRepository listingsRepository)
    {
        _listingsRepository = listingsRepository;
    }

    public async Task<IEnumerable<UserListingResponse>?> Handle(GetAuthorListingsQuery request, CancellationToken cancellationToken)
    {
        var listings = await _listingsRepository.GetUserListingsAsync(request.UserId, cancellationToken);

        return listings.Select(listing => new UserListingResponse(
            listing.Id,
            listing.AuthorId,
            listing.Title,
            listing.Description,
            listing.Price.Amount,
            listing.Price.Currency?.Code,
            listing.Location.ToString(),
            listing.CreatedAt
        ));
    }
}