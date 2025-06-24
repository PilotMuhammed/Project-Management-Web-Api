using MediatR;
using ProjectManagement.Application.Priorities.Commands;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Priorities.Handlers
{
    public class UpdatePriorityCommandHandler : IRequestHandler<UpdatePriorityCommand>
    {
        private readonly IPriorityRepository _repository;

        public UpdatePriorityCommandHandler(IPriorityRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdatePriorityCommand request, CancellationToken cancellationToken)
        {
            var priority = await _repository.GetByIdAsync(request.PriorityId);
            if (priority == null)
                throw new KeyNotFoundException("Priority not found");

            priority.Name = request.Name;

            await _repository.UpdateAsync(priority);
            return Unit.Value;
        }
    }
}
