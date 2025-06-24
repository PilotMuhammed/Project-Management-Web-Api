using MediatR;

namespace ProjectManagement.Application.Notifications.Commands
{
    public class UpdateNotificationCommand : IRequest
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
