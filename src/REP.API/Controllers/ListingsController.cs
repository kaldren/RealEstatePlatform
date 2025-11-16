using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using REP.Modules.Listings.Features.GetSingleListingById;
using REP.Shared.Mediator.Contracts;

namespace REP.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous] // TODO: Remove this after testing
public class ListingsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ListingsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetListings()
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetListingById(int id)
    {
        var result = await _mediator.Send(new GetSingleListingByIdQuery(id));
        return Ok(result);
    }
}
