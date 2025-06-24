using MediatR;
using ProjectManagement.Application.Statuses.Commands;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Statuses.Handlers
{
    public class UpdateStatusCommandHandler : IRequestHandler<UpdateStatusCommand>
    {
        private readonly IStatusRepository _repository;

        public UpdateStatusCommandHandler(IStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
        {
            var status = await _repository.GetByIdAsync(request.StatusId);
            if (status == null)
                throw new KeyNotFoundException("Status not found");

            status.Name = request.Name;

            await _repository.UpdateAsync(status);
            return Unit.Value;
        }
    }
}
