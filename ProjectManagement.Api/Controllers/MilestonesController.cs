using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.DTO.MilestoneDtos;

[ApiController]
[Route("api/[controller]")]
public class MilestonesController : ControllerBase
{
    private readonly IMediator _mediator;
    public MilestonesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MilestoneDto>>> GetAll()
        => Ok(await _mediator.Send(new GetAllMilestonesQuery()));

    [HttpGet("{id}")]
    public async Task<ActionResult<MilestoneDto>> GetById(int id)
        => Ok(await _mediator.Send(new GetMilestoneByIdQuery { MilestoneId = id }));

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateMilestoneCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateMilestoneCommand command)
    {
        if (id != command.MilestoneId) return BadRequest();
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteMilestoneCommand { MilestoneId = id });
        return NoContent();
    }
}
