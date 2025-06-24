using MediatR;

namespace ProjectManagement.Application.Milestones.Commands
{
    public class CreateMilestoneCommand : IRequest<int>
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public int StatusId { get; set; }
    }
}
