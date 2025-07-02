using MediatR;
using ProjectManagement.Application.DTO.MilestoneDtos;
using ProjectManagement.Application.Milestones.Queries;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Milestones.Handlers
{
    public class GetMilestoneByIdQueryHandler : IRequestHandler<GetMilestoneByIdQuery, MilestoneDto>
    {
        private readonly IMilestoneRepository _repository;

        public GetMilestoneByIdQueryHandler(IMilestoneRepository repository)
        {
            _repository = repository;
        }

        public async Task<MilestoneDto> Handle(GetMilestoneByIdQuery request, CancellationToken cancellationToken)
        {
            var milestone = await _repository.GetByIdAsync(request.MilestoneId);
            if (milestone == null)
                return null;

            return new MilestoneDto
            {
                MilestoneId = milestone.MilestoneId,
                ProjectId = milestone.ProjectId,
                Name = milestone.Name,
                DueDate = milestone.DueDate,
                StatusId = milestone.StatusId
            };
        }
    }
}
