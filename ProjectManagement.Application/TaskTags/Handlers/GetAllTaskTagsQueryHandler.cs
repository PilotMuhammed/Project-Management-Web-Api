using MediatR;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.TaskTags.Queries;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.TaskTags.Handlers
{
    public class GetAllTaskTagsQueryHandler : IRequestHandler<GetAllTaskTagsQuery, IEnumerable<TaskTagDto>>
    {
        private readonly ITaskTagRepository _repository;

        public GetAllTaskTagsQueryHandler(ITaskTagRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TaskTagDto>> Handle(GetAllTaskTagsQuery request, CancellationToken cancellationToken)
        {
            var tags = await _repository.GetAllAsync();
            return tags.Select(t => new TaskTagDto
            {
                TaskId = t.TaskId,
                TagId = t.TagId
            }).ToList();
        }
    }
}
