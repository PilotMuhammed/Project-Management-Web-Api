using MediatR;

namespace ProjectManagement.Application.Milestones.Commands
{
    public class DeleteMilestoneCommand : IRequest
    {
        public int MilestoneId { get; set; }
    }
}
