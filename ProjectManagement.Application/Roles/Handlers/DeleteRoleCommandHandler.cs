using MediatR;
using ProjectManagement.Application.Roles.Commands;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Roles.Handlers
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
    {
        private readonly IRoleRepository _repository;

        public DeleteRoleCommandHandler(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.RoleId);
            return Unit.Value;
        }
    }
}
