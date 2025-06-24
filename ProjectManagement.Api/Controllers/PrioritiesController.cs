using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.DTO.PriorityDtos;

[ApiController]
[Route("api/[controller]")]
public class PrioritiesController : ControllerBase
{
    private readonly IMediator _mediator;
    public PrioritiesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PriorityDto>>> GetAll()
        => Ok(await _mediator.Send(new GetAllPrioritiesQuery()));

    [HttpGet("{id}")]
    public async Task<ActionResult<PriorityDto>> GetById(int id)
        => Ok(await _mediator.Send(new GetPriorityByIdQuery { PriorityId = id }));

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreatePriorityCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdatePriorityCommand command)
    {
        if (id != command.PriorityId) return BadRequest();
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeletePriorityCommand { PriorityId = id });
        return NoContent();
    }
}
