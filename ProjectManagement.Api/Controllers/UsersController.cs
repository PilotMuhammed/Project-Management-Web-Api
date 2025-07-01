using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.DTO.UserDtos;
using ProjectManagement.Application.Users.Commands;
using ProjectManagement.Application.Users.Queries;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        => Ok(await _mediator.Send(new GetAllUsersQuery()));

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetById(int id)
        => Ok(await _mediator.Send(new GetUserByIdQuery { UserId = id }));

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateUserCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateUserCommand command)
    {
        if (id != command.UserId) return BadRequest();
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteUserCommand { UserId = id });
        return NoContent();
    }
}
