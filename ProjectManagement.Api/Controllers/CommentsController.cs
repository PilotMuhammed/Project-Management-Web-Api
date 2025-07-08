using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Comments.Commands;
using ProjectManagement.Application.Comments.Queries;
using ProjectManagement.Application.DTO.CommentDtos;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly IMediator _mediator;
    public CommentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CommentDto>>> GetAll()
        => Ok(await _mediator.Send(new GetAllCommentsQuery()));

    [HttpGet("{id}")]
    public async Task<ActionResult<CommentDto>> GetById(int id)
        => Ok(await _mediator.Send(new GetCommentByIdQuery { CommentId = id }));

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateCommentCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCommentCommand command)
    {
        if (id != command.CommentId) return BadRequest();
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteCommentCommand { CommentId = id });
        return NoContent();
    }
}
