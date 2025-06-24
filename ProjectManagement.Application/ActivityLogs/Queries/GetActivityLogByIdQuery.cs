using MediatR;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.ActivityLogDtos;

namespace ProjectManagement.Application.ActivityLogs.Queries
{
    public class GetActivityLogByIdQuery : IRequest<ActivityLogDto>
    {
        public int ActivityId { get; set; }
    }
}
