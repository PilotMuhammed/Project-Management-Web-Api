using MediatR;

namespace ProjectManagement.Application.Comments.Commands
{
    public class DeleteCommentCommand : IRequest
    {
        public int CommentId { get; set; }
    }
}
