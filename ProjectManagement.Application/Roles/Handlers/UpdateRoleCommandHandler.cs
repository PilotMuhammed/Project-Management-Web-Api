using MediatR;
using ProjectManagement.Application.Roles.Commands;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Roles.Handlers
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand>
    {
        private readonly IRoleRepository _repository;

        public UpdateRoleCommandHandler(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _repository.GetByIdAsync(request.RoleId);
            if (role == null)
                throw new KeyNotFoundException("Role not found");

            role.Name = request.Name;

            await _repository.UpdateAsync(role);
            return Unit.Value;
        }
    }
}
