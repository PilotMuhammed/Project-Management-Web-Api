using MediatR;

namespace ProjectManagement.Application.Priorities.Commands
{
    public class UpdatePriorityCommand : IRequest
    {
        public int PriorityId { get; set; }
        public string Name { get; set; }
    }
}
