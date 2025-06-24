using MediatR;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.MilestoneDtos;
using ProjectManagement.Application.Milestones.Queries;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Milestones.Handlers
{
    public class GetAllMilestonesQueryHandler : IRequestHandler<GetAllMilestonesQuery, IEnumerable<MilestoneDto>>
    {
        private readonly IMilestoneRepository _repository;

        public GetAllMilestonesQueryHandler(IMilestoneRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MilestoneDto>> Handle(GetAllMilestonesQuery request, CancellationToken cancellationToken)
        {
            var milestones = await _repository.GetAllAsync();
            return milestones.Select(m => new MilestoneDto
            {
                MilestoneId = m.MilestoneId,
                ProjectId = m.ProjectId,
                Name = m.Name,
                DueDate = m.DueDate,
                StatusId = m.StatusId
            }).ToList();
        }
    }
}
