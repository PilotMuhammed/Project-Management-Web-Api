using MediatR;

namespace ProjectManagement.Application.ActivityLogs.Commands
{
    public class DeleteActivityLogCommand : IRequest
    {
        public int ActivityId { get; set; }
    }
}
