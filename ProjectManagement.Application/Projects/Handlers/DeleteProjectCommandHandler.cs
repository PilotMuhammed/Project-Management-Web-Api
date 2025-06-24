using MediatR;
using ProjectManagement.Application.Projects.Commands;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Projects.Handlers
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
    {
        private readonly IProjectRepository _repository;

        public DeleteProjectCommandHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.ProjectId);
            return Unit.Value;
        }
    }
}
