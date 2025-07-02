using MediatR;
using ProjectManagement.Application.DTO.TagDtos;
using ProjectManagement.Application.Tags.Queries;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Tags.Handlers
{
    public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, TagDto>
    {
        private readonly ITagRepository _repository;

        public GetTagByIdQueryHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<TagDto> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
        {
            var tag = await _repository.GetByIdAsync(request.TagId);
            if (tag == null)
                return null;

            return new TagDto
            {
                TagId = tag.TagId,
                Name = tag.Name
            };
        }
    }
}
