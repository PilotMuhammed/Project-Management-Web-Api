using MediatR;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.NotificationDtos;
using ProjectManagement.Application.Notifications.Queries;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Notifications.Handlers
{
    public class GetAllNotificationsQueryHandler : IRequestHandler<GetAllNotificationsQuery, IEnumerable<NotificationDto>>
    {
        private readonly INotificationRepository _repository;

        public GetAllNotificationsQueryHandler(INotificationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<NotificationDto>> Handle(GetAllNotificationsQuery request, CancellationToken cancellationToken)
        {
            var notifications = await _repository.GetAllAsync();
            return notifications.Select(n => new NotificationDto
            {
                NotificationId = n.NotificationId,
                UserId = n.UserId,
                Message = n.Message,
                IsRead = n.IsRead,
                CreatedAt = n.CreatedAt
            }).ToList();
        }
    }
}
