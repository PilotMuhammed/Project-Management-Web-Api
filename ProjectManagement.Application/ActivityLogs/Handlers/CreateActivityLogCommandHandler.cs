using MediatR;
using ProjectManagement.Application.ActivityLogs.Commands;
using ProjectManagement.Domain.Interfaces;
using ProjectManagement.Domain.Models;

namespace ProjectManagement.Application.ActivityLogs.Handlers
{
    public class CreateActivityLogCommandHandler : IRequestHandler<CreateActivityLogCommand, int>
    {
        private readonly IActivityLogRepository _repository;

        public CreateActivityLogCommandHandler(IActivityLogRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateActivityLogCommand request, CancellationToken cancellationToken)
        {
            var log = new ActivityLog
            {
                UserId = request.UserId,
                Action = request.Action,
                CreatedAt = request.CreatedAt
            };
            await _repository.AddAsync(log);
            return log.ActivityId;
        }
    }
}
