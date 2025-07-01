using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.DTO.TaskWorkDtos;
using ProjectManagement.Application.TaskWorks.Commands;
using ProjectManagement.Application.TaskWorks.Queries;

[ApiController]
[Route("api/[controller]")]
public class TaskWorksController : ControllerBase
{
    private readonly IMediator _mediator;
    public TaskWorksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskWorkDto>>> GetAll()
        => Ok(await _mediator.Send(new GetAllTaskWorksQuery()));

    [HttpGet("{id}")]
    public async Task<ActionResult<TaskWorkDto>> GetById(int id)
        => Ok(await _mediator.Send(new GetTaskWorkByIdQuery { TaskId = id }));

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateTaskWorkCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTaskWorkCommand command)
    {
        if (id != command.TaskId) return BadRequest();
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteTaskWorkCommand { TaskId = id });
        return NoContent();
    }
}
