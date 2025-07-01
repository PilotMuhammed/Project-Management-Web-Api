using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.DTO.TagDtos;
using ProjectManagement.Application.Tags.Commands;
using ProjectManagement.Application.Tags.Queries;

[ApiController]
[Route("api/[controller]")]
public class TagsController : ControllerBase
{
    private readonly IMediator _mediator;
    public TagsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TagDto>>> GetAll()
        => Ok(await _mediator.Send(new GetAllTagsQuery()));

    [HttpGet("{id}")]
    public async Task<ActionResult<TagDto>> GetById(int id)
        => Ok(await _mediator.Send(new GetTagByIdQuery { TagId = id }));

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateTagCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTagCommand command)
    {
        if (id != command.TagId) return BadRequest();
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteTagCommand { TagId = id });
        return NoContent();
    }
}
