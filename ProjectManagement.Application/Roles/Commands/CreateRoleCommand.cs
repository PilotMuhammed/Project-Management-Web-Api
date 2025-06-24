using MediatR;

namespace ProjectManagement.Application.Roles.Commands
{
    public class CreateRoleCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
