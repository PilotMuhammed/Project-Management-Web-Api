using MediatR;
using ProjectManagement.Application.DTO.TaskTagDtos;
using ProjectManagement.Application.TaskTags.Queries;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.TaskTags.Handlers
{
    public class GetTaskTagByIdQueryHandler : IRequestHandler<GetTaskTagByIdQuery, TaskTagDto>
    {
        private readonly ITaskTagRepository _repository;

        public GetTaskTagByIdQueryHandler(ITaskTagRepository repository)
        {
            _repository = repository;
        }

        public async Task<TaskTagDto> Handle(GetTaskTagByIdQuery request, CancellationToken cancellationToken)
        {
            var taskTag = await _repository.GetByIdAsync(request.TaskId, request.TagId);
            if (taskTag == null)
                return null;

            return new TaskTagDto
            {
                TaskId = taskTag.TaskId,
                TagId = taskTag.TagId
            };
        }
    }
}
