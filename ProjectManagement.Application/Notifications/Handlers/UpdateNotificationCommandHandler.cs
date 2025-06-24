using MediatR;
using ProjectManagement.Application.Notifications.Commands;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Notifications.Handlers
{
    public class UpdateNotificationCommandHandler : IRequestHandler<UpdateNotificationCommand>
    {
        private readonly INotificationRepository _repository;

        public UpdateNotificationCommandHandler(INotificationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = await _repository.GetByIdAsync(request.NotificationId);
            if (notification == null)
                throw new KeyNotFoundException("Notification not found");

            notification.UserId = request.UserId;
            notification.Message = request.Message;
            notification.IsRead = request.IsRead;
            notification.CreatedAt = request.CreatedAt;

            await _repository.UpdateAsync(notification);
            return Unit.Value;
        }
    }
}
