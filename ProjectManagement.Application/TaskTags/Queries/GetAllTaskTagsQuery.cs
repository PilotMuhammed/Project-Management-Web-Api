using MediatR;
using ProjectManagement.Application.DTO.TaskTagDtos;

namespace ProjectManagement.Application.TaskTags.Queries
{
    public class GetAllTaskTagsQuery : IRequest<IEnumerable<TaskTagDto>>
    {
    }
}
