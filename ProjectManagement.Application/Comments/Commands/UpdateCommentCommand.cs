using MediatR;

namespace ProjectManagement.Application.Comments.Commands
{
    public class UpdateCommentCommand : IRequest
    {
        public int CommentId { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
