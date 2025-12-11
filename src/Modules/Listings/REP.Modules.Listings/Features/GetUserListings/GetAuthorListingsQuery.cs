using REP.Modules.Listings.Application.Contracts;
using REP.Shared.Kernel;
using REP.Shared.Mediator.Contracts;

namespace REP.Modules.Listings.Application.Features.GetUserListings;

public record GetAuthorListingsQuery(Guid AuthorId) : IRequest<Result<IEnumerable<AuthorListingResponse>>>;

public class GetUserListingsQueryHandler : IRequestHandler<GetAuthorListingsQuery, Result<IEnumerable<AuthorListingResponse>>>
{
    private readonly IListingsRepository _listingsRepository;

    public GetUserListingsQueryHandler(IListingsRepository listingsRepository)
    {
        _listingsRepository = listingsRepository;
    }

    public async Task<Result<IEnumerable<AuthorListingResponse>>> Handle(GetAuthorListingsQuery request, CancellationToken cancellationToken)
    {
        var listings = await _listingsRepository.GetUserListingsAsync(request.AuthorId, cancellationToken);

        if (listings == null)
        {
            return Result<IEnumerable<AuthorListingResponse>>.Ok(Enumerable.Empty<AuthorListingResponse>());
        }
        else
        {
            return Result<IEnumerable<AuthorListingResponse>>.Ok(listings.Select(listing => new AuthorListingResponse(
            listing.Id,
            listing.AuthorId,
            listing.Title,
            listing.Description,
            listing.Price.Amount,
            listing.Price.Currency?.Code,
            listing.Location.ToString(),
            listing.CreatedAt
        )));
        }
    }
}