using MediatR;
using ProjectManagement.Application.DTO.RoleDtos;

namespace ProjectManagement.Application.Roles.Queries
{
    public class GetRoleByIdQuery : IRequest<RoleDto>
    {
        public int RoleId { get; set; }
    }
}
