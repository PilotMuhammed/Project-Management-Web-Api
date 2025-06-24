using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.DTO.NotificationDtos;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly IMediator _mediator;
    public NotificationsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<NotificationDto>>> GetAll()
        => Ok(await _mediator.Send(new GetAllNotificationsQuery()));

    [HttpGet("{id}")]
    public async Task<ActionResult<NotificationDto>> GetById(int id)
        => Ok(await _mediator.Send(new GetNotificationByIdQuery { NotificationId = id }));

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateNotificationCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateNotificationCommand command)
    {
        if (id != command.NotificationId) return BadRequest();
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteNotificationCommand { NotificationId = id });
        return NoContent();
    }
}
