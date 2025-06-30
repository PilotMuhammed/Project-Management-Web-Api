using MediatR;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.ProjectsDtos;
using ProjectManagement.Application.Projects.Queries;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Projects.Handlers
{
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, IEnumerable<ProjectDto>>
    {
        private readonly IProjectRepository _repository;

        public GetAllProjectsQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProjectDto>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _repository.GetAllAsync();
            //  AutoMapper أو Mapster هنا
            return projects.Select(p => new ProjectDto
            {
                ProjectId = p.ProjectId,
                Name = p.Name,
                Description = p.Description,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                StatusId = p.StatusId
            }).ToList();
        }
    }
}
