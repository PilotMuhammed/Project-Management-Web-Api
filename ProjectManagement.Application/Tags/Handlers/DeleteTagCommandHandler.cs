using MediatR;
using ProjectManagement.Application.Tags.Commands;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Tags.Handlers
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand>
    {
        private readonly ITagRepository _repository;

        public DeleteTagCommandHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.TagId);
            return Unit.Value;
        }
    }
}
