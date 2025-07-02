using MediatR;
using ProjectManagement.Application.DTO.RoleDtos;
using ProjectManagement.Application.Roles.Queries;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Roles.Handlers
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<RoleDto>>
    {
        private readonly IRoleRepository _repository;

        public GetAllRolesQueryHandler(IRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RoleDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _repository.GetAllAsync();
            return roles.Select(r => new RoleDto
            {
                RoleId = r.RoleId,
                Name = r.Name
            }).ToList();
        }
    }
}
