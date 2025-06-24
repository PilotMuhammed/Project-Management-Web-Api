using MediatR;
using ProjectManagement.Application.DTO;

namespace ProjectManagement.Application.TaskTags.Queries
{
    public class GetAllTaskTagsQuery : IRequest<IEnumerable<TaskTagDto>>
    {
    }
}
