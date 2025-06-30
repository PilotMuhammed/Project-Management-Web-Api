using MediatR;

namespace ProjectManagement.Application.Roles.Commands
{
    public class UpdateRoleCommand : IRequest
    {
        public int RoleId { get; set; }
        public string? Name { get; set; }
    }
}
