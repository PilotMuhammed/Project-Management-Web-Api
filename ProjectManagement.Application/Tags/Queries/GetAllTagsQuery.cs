using MediatR;
using ProjectManagement.Application.DTO.TagDtos;

namespace ProjectManagement.Application.Tags.Queries
{
    public class GetAllTagsQuery : IRequest<IEnumerable<TagDto>>
    {
    }
}
