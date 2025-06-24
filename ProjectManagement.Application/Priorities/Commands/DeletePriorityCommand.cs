using MediatR;

namespace ProjectManagement.Application.Priorities.Commands
{
    public class DeletePriorityCommand : IRequest
    {
        public int PriorityId { get; set; }
    }
}
