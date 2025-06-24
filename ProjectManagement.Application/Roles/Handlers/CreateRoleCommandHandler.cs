using MediatR;
using ProjectManagement.Application.Roles.Commands;
using ProjectManagement.Domain.Interfaces;
using ProjectManagement.Domain.Models;

namespace ProjectManagement.Application.Roles.Handlers
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, int>
    {
        private readonly IRoleRepository _repository;

        public CreateRoleCommandHandler(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = new Role
            {
                Name = request.Name
            };
            await _repository.AddAsync(role);
            return role.RoleId;
        }
    }
}
