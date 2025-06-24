using MediatR;
using ProjectManagement.Application.Priorities.Commands;
using ProjectManagement.Domain.Interfaces;
using ProjectManagement.Domain.Models;

namespace ProjectManagement.Application.Priorities.Handlers
{
    public class CreatePriorityCommandHandler : IRequestHandler<CreatePriorityCommand, int>
    {
        private readonly IPriorityRepository _repository;

        public CreatePriorityCommandHandler(IPriorityRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreatePriorityCommand request, CancellationToken cancellationToken)
        {
            var priority = new Priority
            {
                Name = request.Name
            };
            await _repository.AddAsync(priority);
            return priority.PriorityId;
        }
    }
}
