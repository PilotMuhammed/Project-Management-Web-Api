using MediatR;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.TagDtos;
using ProjectManagement.Application.Tags.Queries;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Tags.Handlers
{
    public class GetAllTagsQueryHandler : IRequestHandler<GetAllTagsQuery, IEnumerable<TagDto>>
    {
        private readonly ITagRepository _repository;

        public GetAllTagsQueryHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TagDto>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
        {
            var tags = await _repository.GetAllAsync();
            return tags.Select(t => new TagDto
            {
                TagId = t.TagId,
                Name = t.Name
            }).ToList();
        }
    }
}
