using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RealEstatePlatform.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous] // TODO: Remove this after testing
public class ListingsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetListings()
    {
        return Ok(new[] { "Listing1", "Listing2", "Listing3" });
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetListingById(int id)
    {
        return Ok($"Listing {id}");
    }
}
