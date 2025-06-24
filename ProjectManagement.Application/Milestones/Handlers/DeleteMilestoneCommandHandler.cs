using MediatR;
using ProjectManagement.Application.Milestones.Commands;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Milestones.Handlers
{
    public class DeleteMilestoneCommandHandler : IRequestHandler<DeleteMilestoneCommand>
    {
        private readonly IMilestoneRepository _repository;

        public DeleteMilestoneCommandHandler(IMilestoneRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteMilestoneCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.MilestoneId);
            return Unit.Value;
        }
    }
}
