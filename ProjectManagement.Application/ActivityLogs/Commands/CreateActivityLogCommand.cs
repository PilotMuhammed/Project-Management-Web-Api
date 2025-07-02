using MediatR;

namespace ProjectManagement.Application.ActivityLogs.Commands
{
    public class CreateActivityLogCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string? Action { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
