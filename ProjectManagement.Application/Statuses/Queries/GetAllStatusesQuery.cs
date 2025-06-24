using MediatR;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.StatusDtos;

namespace ProjectManagement.Application.Statuses.Queries
{
    public class GetAllStatusesQuery : IRequest<IEnumerable<StatusDto>>
    {
    }
}
