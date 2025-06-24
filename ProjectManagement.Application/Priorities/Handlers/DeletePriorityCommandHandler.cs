using MediatR;
using ProjectManagement.Application.Priorities.Commands;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Priorities.Handlers
{
    public class DeletePriorityCommandHandler : IRequestHandler<DeletePriorityCommand>
    {
        private readonly IPriorityRepository _repository;

        public DeletePriorityCommandHandler(IPriorityRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeletePriorityCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.PriorityId);
            return Unit.Value;
        }
    }
}
