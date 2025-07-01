using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.ActivityLogs.Commands;
using ProjectManagement.Application.ActivityLogs.Queries;
using ProjectManagement.Application.DTO.ActivityLogDtos;

[ApiController]
[Route("api/[controller]")]
public class ActivityLogsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ActivityLogsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ActivityLogDto>>> GetAll()
        => Ok(await _mediator.Send(new GetAllActivityLogsQuery()));

    [HttpGet("{id}")]
    public async Task<ActionResult<ActivityLogDto>> GetById(int id)
        => Ok(await _mediator.Send(new GetActivityLogByIdQuery { ActivityId = id }));

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateActivityLogCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteActivityLogCommand { ActivityId = id });
        return NoContent();
    }
}
