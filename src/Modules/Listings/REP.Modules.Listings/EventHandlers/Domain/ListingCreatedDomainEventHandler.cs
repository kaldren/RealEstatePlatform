namespace REP.Modules.Listings.Application.EventHandlers.Domain;

// Domain events are for handling events that occur within the same domain.
// Thus, once a listing is created, various actions might need to be taken, such as sending notifications, updating related records, or logging the event for auditing purposes.
// If we want to push integration events to other services or bounded contexts, we should use Integration Events instead of Domain Events.

// Integration events are for handling events that need to be communicated across different services or bounded contexts.
// I will push integration event so that at the other side there will be an AI that checks if the listing is compliant with the platform policies before it gets published.
public class ListingCreatedDomainEventHandler
{
}
