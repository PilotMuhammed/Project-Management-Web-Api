using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.DTO.StatusDtos;
using ProjectManagement.Application.Statuses.Commands;
using ProjectManagement.Application.Statuses.Queries;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class StatusesController : ControllerBase
{
    private readonly IMediator _mediator;
    public StatusesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StatusDto>>> GetAll()
        => Ok(await _mediator.Send(new GetAllStatusesQuery()));

    [HttpGet("{id}")]
    public async Task<ActionResult<StatusDto>> GetById(int id)
        => Ok(await _mediator.Send(new GetStatusByIdQuery { StatusId = id }));

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateStatusCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateStatusCommand command)
    {
        if (id != command.StatusId) return BadRequest();
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteStatusCommand { StatusId = id });
        return NoContent();
    }
}
