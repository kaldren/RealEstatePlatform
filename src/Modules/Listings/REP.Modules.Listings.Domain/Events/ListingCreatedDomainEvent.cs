using REP.Shared.Kernel.Abstractions;

namespace REP.Modules.Listings.Domain.Events;

public record ListingCreatedDomainEvent(
    Guid ListingId,
    Guid AuthorId,
    string Title,
    string Description,
    decimal? Amount,
    string? CurrencyCode,
    string Address
) : IDomainEvent;
