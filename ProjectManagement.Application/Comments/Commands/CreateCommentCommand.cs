using MediatR;

namespace ProjectManagement.Application.Comments.Commands
{
    public class CreateCommentCommand : IRequest<int>
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
