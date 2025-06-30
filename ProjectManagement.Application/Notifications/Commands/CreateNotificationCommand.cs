using MediatR;

namespace ProjectManagement.Application.Notifications.Commands
{
    public class CreateNotificationCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string? Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
