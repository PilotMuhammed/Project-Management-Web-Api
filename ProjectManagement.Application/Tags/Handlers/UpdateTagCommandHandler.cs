using MediatR;
using ProjectManagement.Application.Tags.Commands;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Tags.Handlers
{
    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand>
    {
        private readonly ITagRepository _repository;

        public UpdateTagCommandHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            var tag = await _repository.GetByIdAsync(request.TagId);
            if (tag == null)
                throw new KeyNotFoundException("Tag not found");

            tag.Name = request.Name;

            await _repository.UpdateAsync(tag);
            return Unit.Value;
        }
    }
}
