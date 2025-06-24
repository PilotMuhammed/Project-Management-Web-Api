using MediatR;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.CommentDtos;

namespace ProjectManagement.Application.Comments.Queries
{
    public class GetAllCommentsQuery : IRequest<IEnumerable<CommentDto>>
    {
    }
}
