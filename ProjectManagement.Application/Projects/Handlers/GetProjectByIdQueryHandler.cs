using MediatR;
using ProjectManagement.Application.DTO.ProjectsDtos;
using ProjectManagement.Application.Projects.Queries;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Projects.Handlers
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDto>
    {
        private readonly IProjectRepository _repository;

        public GetProjectByIdQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProjectDto> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetByIdAsync(request.ProjectId);
            if (project == null)
                return null;

            return new ProjectDto
            {
                ProjectId = project.ProjectId,
                Name = project.Name,
                Description = project.Description,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                StatusId = project.StatusId
            };
        }
    }
}
