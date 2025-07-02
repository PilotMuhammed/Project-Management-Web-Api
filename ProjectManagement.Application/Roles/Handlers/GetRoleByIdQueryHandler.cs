using MediatR;
using ProjectManagement.Application.DTO.RoleDtos;
using ProjectManagement.Application.Roles.Queries;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Roles.Handlers
{
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RoleDto>
    {
        private readonly IRoleRepository _repository;

        public GetRoleByIdQueryHandler(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<RoleDto> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _repository.GetByIdAsync(request.RoleId);
            if (role == null)
                return null;

            return new RoleDto
            {
                RoleId = role.RoleId,
                Name = role.Name
            };
        }
    }
}
