using MediatR;
using ProjectManagement.Application.DTO.TaskTagDtos;

namespace ProjectManagement.Application.TaskTags.Queries
{
    public class GetTaskTagByIdQuery : IRequest<TaskTagDto>
    {
        public int TaskId { get; set; }
        public int TagId { get; set; }
    }
}
