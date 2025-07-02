using MediatR;
using ProjectManagement.Application.DTO.RoleDtos;

namespace ProjectManagement.Application.Roles.Queries
{
    public class GetAllRolesQuery : IRequest<IEnumerable<RoleDto>>
    {
    }
}
