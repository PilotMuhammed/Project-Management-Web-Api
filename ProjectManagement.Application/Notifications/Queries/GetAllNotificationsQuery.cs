using MediatR;
using ProjectManagement.Application.DTO.NotificationDtos;

namespace ProjectManagement.Application.Notifications.Queries
{
    public class GetAllNotificationsQuery : IRequest<IEnumerable<NotificationDto>>
    {
    }
}
