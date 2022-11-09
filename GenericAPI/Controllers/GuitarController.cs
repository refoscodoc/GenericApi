using GenericAPI.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

using GenericApplication.Features.Requests.Queries;

namespace GenericAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GuitarController : ControllerBase
{
    private readonly IMediator _mediator;

    public GuitarController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GuitarDto>> Get(Guid id)
    {
        var guitar = await _mediator.Send(new GetGuitarQuery { Id = id });
        return Ok(guitar);
    }
}