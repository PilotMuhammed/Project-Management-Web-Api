using MediatR;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.MilestoneDtos;

namespace ProjectManagement.Application.Milestones.Queries
{
    public class GetAllMilestonesQuery : IRequest<IEnumerable<MilestoneDto>>
    {
    }
}
