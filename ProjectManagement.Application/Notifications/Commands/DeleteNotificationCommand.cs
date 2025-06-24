using MediatR;

namespace ProjectManagement.Application.Notifications.Commands
{
    public class DeleteNotificationCommand : IRequest
    {
        public int NotificationId { get; set; }
    }
}
