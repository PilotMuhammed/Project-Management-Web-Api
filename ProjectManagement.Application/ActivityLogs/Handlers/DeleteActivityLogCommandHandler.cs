using MediatR;
using ProjectManagement.Application.ActivityLogs.Commands;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.ActivityLogs.Handlers
{
    public class DeleteActivityLogCommandHandler : IRequestHandler<DeleteActivityLogCommand>
    {
        private readonly IActivityLogRepository _repository;

        public DeleteActivityLogCommandHandler(IActivityLogRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteActivityLogCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.ActivityId);
            return Unit.Value;
        }
    }
}
