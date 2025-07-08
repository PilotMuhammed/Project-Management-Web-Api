using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.DTO.TaskTagDtos;
using ProjectManagement.Application.TaskTags.Commands;
using ProjectManagement.Application.TaskTags.Queries;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TaskTagsController : ControllerBase
{
    private readonly IMediator _mediator;
    public TaskTagsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskTagDto>>> GetAll()
        => Ok(await _mediator.Send(new GetAllTaskTagsQuery()));

    [HttpGet("{taskId}/{tagId}")]
    public async Task<ActionResult<TaskTagDto>> GetById(int taskId, int tagId)
        => Ok(await _mediator.Send(new GetTaskTagByIdQuery { TaskId = taskId, TagId = tagId }));

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateTaskTagCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{taskId}/{tagId}")]
    public async Task<IActionResult> Delete(int taskId, int tagId)
    {
        await _mediator.Send(new DeleteTaskTagCommand { TaskId = taskId, TagId = tagId });
        return NoContent();
    }
}
