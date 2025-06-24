using MediatR;
using ProjectManagement.Application.Projects.Commands;
using ProjectManagement.Domain.Models;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Projects.Handlers
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
    {
        private readonly IProjectRepository _repository;

        public UpdateProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _repository.GetByIdAsync(request.ProjectId);
            if (project == null)
                throw new KeyNotFoundException("Project not found");

            project.Name = request.Name;
            project.Description = request.Description;
            project.StartDate = request.StartDate;
            project.EndDate = request.EndDate;
            project.StatusId = request.StatusId;

            await _repository.UpdateAsync(project);
            return Unit.Value;
        }
    }
}
