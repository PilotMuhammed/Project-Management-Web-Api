using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.Projects.Commands;
using ProjectManagement.Application.Projects.Queries;

namespace ProjectManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetAll()
        {
            var projects = await _mediator.Send(new GetAllProjectsQuery());
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> GetById(int id)
        {
            var project = await _mediator.Send(new GetProjectByIdQuery { ProjectId = id });
            if (project == null)
                return NotFound();
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateProjectCommand command)
        {
            var projectId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = projectId }, projectId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProjectCommand command)
        {
            if (id != command.ProjectId)
                return BadRequest();
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteProjectCommand { ProjectId = id });
            return NoContent();
        }
    }
}
