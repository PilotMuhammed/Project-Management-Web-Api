using MediatR;
using ProjectManagement.Application.DTO.PriorityDtos;

namespace ProjectManagement.Application.Priorities.Queries
{
    public class GetPriorityByIdQuery : IRequest<PriorityDto>
    {
        public int PriorityId { get; set; }
    }
}
