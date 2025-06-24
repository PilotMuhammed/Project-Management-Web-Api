using MediatR;
using ProjectManagement.Application.TaskTags.Commands;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.TaskTags.Handlers
{
    public class DeleteTaskTagCommandHandler : IRequestHandler<DeleteTaskTagCommand>
    {
        private readonly ITaskTagRepository _repository;

        public DeleteTaskTagCommandHandler(ITaskTagRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteTaskTagCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.TaskId, request.TagId);
            return Unit.Value;
        }
    }
}
