using MediatR;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.MilestoneDtos;

namespace ProjectManagement.Application.Milestones.Queries
{
    public class GetMilestoneByIdQuery : IRequest<MilestoneDto>
    {
        public int MilestoneId { get; set; }
    }
}
