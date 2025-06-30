using MediatR;
using ProjectManagement.Application.ActivityLogs.Queries;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.ActivityLogDtos;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.ActivityLogs.Handlers
{
    public class GetAllActivityLogsQueryHandler : IRequestHandler<GetAllActivityLogsQuery, IEnumerable<ActivityLogDto>>
    {
        private readonly IActivityLogRepository _repository;

        public GetAllActivityLogsQueryHandler(IActivityLogRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ActivityLogDto>> Handle(GetAllActivityLogsQuery request, CancellationToken cancellationToken)
        {
            var logs = await _repository.GetAllAsync();
            return logs.Select(l => new ActivityLogDto
            {
                ActivityId = l.ActivityLogId,
                UserId = l.UserId,
                Action = l.Action,
                CreatedAt = l.CreatedAt
            }).ToList();
        }
    }
}
