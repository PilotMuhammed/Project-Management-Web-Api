using MediatR;
using ProjectManagement.Application.DTO.ActivityLogDtos;

namespace ProjectManagement.Application.ActivityLogs.Queries
{
    public class GetAllActivityLogsQuery : IRequest<IEnumerable<ActivityLogDto>>
    {
    }
}
