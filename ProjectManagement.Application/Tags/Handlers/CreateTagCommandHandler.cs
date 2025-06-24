using MediatR;
using ProjectManagement.Application.Tags.Commands;
using ProjectManagement.Domain.Interfaces;
using ProjectManagement.Domain.Models;

namespace ProjectManagement.Application.Tags.Handlers
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, int>
    {
        private readonly ITagRepository _repository;

        public CreateTagCommandHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var tag = new Tag
            {
                Name = request.Name
            };
            await _repository.AddAsync(tag);
            return tag.TagId;
        }
    }
}
