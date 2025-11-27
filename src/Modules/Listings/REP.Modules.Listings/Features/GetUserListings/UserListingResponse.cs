using System;
using System.Collections.Generic;
using System.Text;

namespace REP.Modules.Listings.Application.Features.GetUserListings;

public record UserListingResponse(
    Guid Id,
    Guid OwnerId,
    string Title,
    string Description,
    decimal Price,
    string Address,
    DateTimeOffset CreatedAt
);