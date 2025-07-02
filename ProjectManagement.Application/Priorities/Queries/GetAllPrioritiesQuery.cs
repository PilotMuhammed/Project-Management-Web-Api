using MediatR;
using ProjectManagement.Application.DTO.PriorityDtos;

namespace ProjectManagement.Application.Priorities.Queries
{
    public class GetAllPrioritiesQuery : IRequest<IEnumerable<PriorityDto>>
    {
    }
}
