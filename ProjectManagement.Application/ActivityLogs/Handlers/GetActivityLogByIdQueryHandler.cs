using MediatR;
using ProjectManagement.Application.ActivityLogs.Queries;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.ActivityLogDtos;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.ActivityLogs.Handlers
{
    public class GetActivityLogByIdQueryHandler : IRequestHandler<GetActivityLogByIdQuery, ActivityLogDto>
    {
        private readonly IActivityLogRepository _repository;

        public GetActivityLogByIdQueryHandler(IActivityLogRepository repository)
        {
            _repository = repository;
        }

        public async Task<ActivityLogDto> Handle(GetActivityLogByIdQuery request, CancellationToken cancellationToken)
        {
            var log = await _repository.GetByIdAsync(request.ActivityId);
            if (log == null)
                return null;

            return new ActivityLogDto
            {
                ActivityId = log.ActivityLogId,
                UserId = log.UserId,
                Action = log.Action,
                CreatedAt = log.CreatedAt
            };
        }
    }
}
