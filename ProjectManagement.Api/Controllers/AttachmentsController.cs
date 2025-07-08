using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Attachments.Commands;
using ProjectManagement.Application.Attachments.Queries;
using ProjectManagement.Application.DTO.AttachmentDtos;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AttachmentsController : ControllerBase
{
    private readonly IMediator _mediator;
    public AttachmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AttachmentDto>>> GetAll()
        => Ok(await _mediator.Send(new GetAllAttachmentsQuery()));

    [HttpGet("{id}")]
    public async Task<ActionResult<AttachmentDto>> GetById(int id)
        => Ok(await _mediator.Send(new GetAttachmentByIdQuery { AttachmentId = id }));

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateAttachmentCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateAttachmentCommand command)
    {
        if (id != command.AttachmentId) return BadRequest();
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteAttachmentCommand { AttachmentId = id });
        return NoContent();
    }
}
