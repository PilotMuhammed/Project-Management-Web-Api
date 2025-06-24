using MediatR;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.NotificationDtos;
using ProjectManagement.Application.Notifications.Queries;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Notifications.Handlers
{
    public class GetNotificationByIdQueryHandler : IRequestHandler<GetNotificationByIdQuery, NotificationDto>
    {
        private readonly INotificationRepository _repository;

        public GetNotificationByIdQueryHandler(INotificationRepository repository)
        {
            _repository = repository;
        }

        public async Task<NotificationDto> Handle(GetNotificationByIdQuery request, CancellationToken cancellationToken)
        {
            var notification = await _repository.GetByIdAsync(request.NotificationId);
            if (notification == null)
                return null;

            return new NotificationDto
            {
                NotificationId = notification.NotificationId,
                UserId = notification.UserId,
                Message = notification.Message,
                IsRead = notification.IsRead,
                CreatedAt = notification.CreatedAt
            };
        }
    }
}
