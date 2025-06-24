using MediatR;
using ProjectManagement.Application.Notifications.Commands;
using ProjectManagement.Domain.Interfaces;
using ProjectManagement.Domain.Models;

namespace ProjectManagement.Application.Notifications.Handlers
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, int>
    {
        private readonly INotificationRepository _repository;

        public CreateNotificationCommandHandler(INotificationRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = new Notification
            {
                UserId = request.UserId,
                Message = request.Message,
                IsRead = request.IsRead,
                CreatedAt = request.CreatedAt
            };
            await _repository.AddAsync(notification);
            return notification.NotificationId;
        }
    }
}
