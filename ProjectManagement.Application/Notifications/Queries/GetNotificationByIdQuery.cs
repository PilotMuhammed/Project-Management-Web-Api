using MediatR;
using ProjectManagement.Application.DTO.NotificationDtos;

namespace ProjectManagement.Application.Notifications.Queries
{
    public class GetNotificationByIdQuery : IRequest<NotificationDto>
    {
        public int NotificationId { get; set; }
    }
}
