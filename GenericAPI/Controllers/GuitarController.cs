using GenericAPI.Dtos;
using GenericAPI.Models;
using GenericApplication.Features.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

using GenericApplication.Features.Requests.Queries;
using GenericDomain.Models;

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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GuitarModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GuitarDto>> Get(Guid id)
    {
        var guitar = await _mediator.Send(new GetGuitarQuery { Id = id });
        return Ok(guitar);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GuitarModel))]
    public async Task<ActionResult<GuitarDto>> Post(GuitarDto guitar)
    {
        var result = await _mediator.Send(new CreateGuitarCommand {CreateGuitarDto = guitar});
        return Ok(result);
    }
}