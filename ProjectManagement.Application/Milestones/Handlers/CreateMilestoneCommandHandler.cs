using MediatR;
using ProjectManagement.Application.Milestones.Commands;
using ProjectManagement.Domain.Interfaces;
using ProjectManagement.Domain.Models;

namespace ProjectManagement.Application.Milestones.Handlers
{
    public class CreateMilestoneCommandHandler : IRequestHandler<CreateMilestoneCommand, int>
    {
        private readonly IMilestoneRepository _repository;

        public CreateMilestoneCommandHandler(IMilestoneRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateMilestoneCommand request, CancellationToken cancellationToken)
        {
            var milestone = new Milestone
            {
                ProjectId = request.ProjectId,
                Name = request.Name,
                DueDate = request.DueDate,
                StatusId = request.StatusId
            };
            await _repository.AddAsync(milestone);
            return milestone.MilestoneId;
        }
    }
}
