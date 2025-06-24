using MediatR;
using ProjectManagement.Application.Notifications.Commands;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Notifications.Handlers
{
    public class DeleteNotificationCommandHandler : IRequestHandler<DeleteNotificationCommand>
    {
        private readonly INotificationRepository _repository;

        public DeleteNotificationCommandHandler(INotificationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.NotificationId);
            return Unit.Value;
        }
    }
}
