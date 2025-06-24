using MediatR;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.TagDtos;

namespace ProjectManagement.Application.Tags.Queries
{
    public class GetTagByIdQuery : IRequest<TagDto>
    {
        public int TagId { get; set; }
    }
}
