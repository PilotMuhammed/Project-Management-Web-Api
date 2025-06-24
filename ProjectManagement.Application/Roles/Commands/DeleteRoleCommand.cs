using MediatR;

namespace ProjectManagement.Application.Roles.Commands
{
    public class DeleteRoleCommand : IRequest
    {
        public int RoleId { get; set; }
    }
}
