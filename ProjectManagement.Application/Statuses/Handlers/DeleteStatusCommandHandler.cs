using MediatR;
using ProjectManagement.Application.Statuses.Commands;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Statuses.Handlers
{
    public class DeleteStatusCommandHandler : IRequestHandler<DeleteStatusCommand>
    {
        private readonly IStatusRepository _repository;

        public DeleteStatusCommandHandler(IStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteStatusCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.StatusId);
            return Unit.Value;
        }
    }
}
