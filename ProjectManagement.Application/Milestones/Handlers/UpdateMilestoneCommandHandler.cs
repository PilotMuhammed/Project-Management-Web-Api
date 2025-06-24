using MediatR;
using ProjectManagement.Application.Milestones.Commands;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Milestones.Handlers
{
    public class UpdateMilestoneCommandHandler : IRequestHandler<UpdateMilestoneCommand>
    {
        private readonly IMilestoneRepository _repository;

        public UpdateMilestoneCommandHandler(IMilestoneRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateMilestoneCommand request, CancellationToken cancellationToken)
        {
            var milestone = await _repository.GetByIdAsync(request.MilestoneId);
            if (milestone == null)
                throw new KeyNotFoundException("Milestone not found");

            milestone.ProjectId = request.ProjectId;
            milestone.Name = request.Name;
            milestone.DueDate = request.DueDate;
            milestone.StatusId = request.StatusId;

            await _repository.UpdateAsync(milestone);
            return Unit.Value;
        }
    }
}
