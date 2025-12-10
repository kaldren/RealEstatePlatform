using System.ComponentModel.DataAnnotations;

namespace REP.Modules.Listings.Application.Features.CreateListing;

// Here we're using record because this is a simple data carrier for the request to create a listing.
// If it were to have behavior or complex logic, we might consider using a class instead.
// Why not a class: Records provide built-in value-based equality, immutability, and concise syntax for defining data carriers.
// So, for example, we can't accidentally change the properties of the request after it's created, which helps maintain data integrity.
public record CreateListingRequest : IValidatableObject
{
    public required Guid AuthorId { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required string Address { get; init; }
    public required decimal Price { get; init; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(Title))
        {
            yield return new ValidationResult("Title is required.", new[] { nameof(Title) });
        }
        if (string.IsNullOrWhiteSpace(Description))
        {
            yield return new ValidationResult("Description is required.", new[] { nameof(Description) });
        }
        if (string.IsNullOrWhiteSpace(Address))
        {
            yield return new ValidationResult("Address is required.", new[] { nameof(Address) });
        }
        if (Price <= 0)
        {
            yield return new ValidationResult("Price must be greater than zero.", new[] { nameof(Price) });
        }
    }
}