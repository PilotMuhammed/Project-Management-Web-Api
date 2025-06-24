using MediatR;
using ProjectManagement.Application.TaskTags.Commands;
using ProjectManagement.Domain.Interfaces;
using ProjectManagement.Domain.Models;

namespace ProjectManagement.Application.TaskTags.Handlers
{
    public class CreateTaskTagCommandHandler : IRequestHandler<CreateTaskTagCommand>
    {
        private readonly ITaskTagRepository _repository;

        public CreateTaskTagCommandHandler(ITaskTagRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateTaskTagCommand request, CancellationToken cancellationToken)
        {
            var taskTag = new TaskTag
            {
                TaskId = request.TaskId,
                TagId = request.TagId
            };
            await _repository.AddAsync(taskTag);
            return Unit.Value;
        }
    }
}
