using MediatR;

namespace ProjectManagement.Application.Priorities.Commands
{
    public class CreatePriorityCommand : IRequest<int>
    {
        public string? Name { get; set; }
    }
}
