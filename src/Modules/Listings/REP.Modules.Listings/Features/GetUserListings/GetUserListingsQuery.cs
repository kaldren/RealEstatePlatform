using REP.Modules.Listings.Application.Contracts;
using REP.Modules.Listings.Application.Features.GetSingleListingById;
using REP.Shared.Mediator.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace REP.Modules.Listings.Application.Features.GetUserListings;

public record GetUserListingsQuery(Guid UserId) : IRequest<IEnumerable<UserListingResponse>?>;

public class GetUserListingsQueryHandler : IRequestHandler<GetUserListingsQuery, IEnumerable<UserListingResponse>?>
{
    private readonly IListingsRepository _listingsRepository;

    public GetUserListingsQueryHandler(IListingsRepository listingsRepository)
    {
        _listingsRepository = listingsRepository;
    }

    public async Task<IEnumerable<UserListingResponse>?> Handle(GetUserListingsQuery request, CancellationToken cancellationToken)
    {
        var listings = await _listingsRepository.GetUserListings(request.UserId, cancellationToken);

        return listings.Select(listing => new UserListingResponse(
            listing.Id,
            listing.OwnerId,
            listing.Title,
            listing.Description,
            listing.Price,
            listing.Address,
            listing.CreatedAt
        ));
    }
}