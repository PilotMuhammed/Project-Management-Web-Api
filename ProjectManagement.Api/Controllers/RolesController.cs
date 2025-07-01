using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.DTO.RoleDtos;
using ProjectManagement.Application.Roles.Commands;
using ProjectManagement.Application.Roles.Queries;

[ApiController]
[Route("api/[controller]")]
public class RolesController : ControllerBase
{
    private readonly IMediator _mediator;
    public RolesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoleDto>>> GetAll()
        => Ok(await _mediator.Send(new GetAllRolesQuery()));

    [HttpGet("{id}")]
    public async Task<ActionResult<RoleDto>> GetById(int id)
        => Ok(await _mediator.Send(new GetRoleByIdQuery { RoleId = id }));

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateRoleCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateRoleCommand command)
    {
        if (id != command.RoleId) return BadRequest();
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteRoleCommand { RoleId = id });
        return NoContent();
    }
}
