using MediatR;
using ProjectManagement.Application.Statuses.Commands;
using ProjectManagement.Domain.Models;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Statuses.Handlers
{
    public class CreateStatusCommandHandler : IRequestHandler<CreateStatusCommand, int>
    {
        private readonly IStatusRepository _repository;

        public CreateStatusCommandHandler(IStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateStatusCommand request, CancellationToken cancellationToken)
        {
            var status = new Status
            {
                Name = request.Name
            };
            await _repository.AddAsync(status);
            return status.StatusId;
        }
    }
}
