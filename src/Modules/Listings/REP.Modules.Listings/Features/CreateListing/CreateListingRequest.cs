using System.ComponentModel.DataAnnotations;

namespace REP.Modules.Listings.Application.Features.CreateListing;

// Here we're using record because this is a simple data carrier for the request to create a listing.
// If it were to have behavior or complex logic, we might consider using a class instead.
// Why not a class: Records provide built-in value-based equality, immutability, and concise syntax for defining data carriers.
// So, for example, we can't accidentally change the properties of the request after it's created, which helps maintain data integrity.
public record CreateListingRequest (Guid AuthorId, [Required, MinLength(5)] string Title, [Required, MinLength(20)] string Description, [Required] string Address, [Required, Range(1, int.MaxValue)] decimal Price);