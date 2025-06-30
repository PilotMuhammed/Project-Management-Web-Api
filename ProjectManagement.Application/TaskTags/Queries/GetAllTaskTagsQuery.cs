using MediatR;
using ProjectManagement.Application.DTO.TaskTagDtos;
using System.Collections.Generic;

namespace ProjectManagement.Application.TaskTags.Queries
{
    public class GetAllTaskTagsQuery : IRequest<IEnumerable<TaskTagDto>>
    {
    }
}
