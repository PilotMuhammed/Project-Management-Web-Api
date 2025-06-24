using MediatR;

namespace ProjectManagement.Application.Milestones.Commands
{
    public class UpdateMilestoneCommand : IRequest
    {
        public int MilestoneId { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public int StatusId { get; set; }
    }
}
