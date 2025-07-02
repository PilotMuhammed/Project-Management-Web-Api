using MediatR;
using ProjectManagement.Application.DTO.StatusDtos;

namespace ProjectManagement.Application.Statuses.Queries
{
    public class GetStatusByIdQuery : IRequest<StatusDto>
    {
        public int StatusId { get; set; }
    }
}
