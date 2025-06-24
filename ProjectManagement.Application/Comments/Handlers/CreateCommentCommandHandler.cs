using MediatR;
using ProjectManagement.Application.Comments.Commands;
using ProjectManagement.Domain.Interfaces;
using ProjectManagement.Domain.Models;

namespace ProjectManagement.Application.Comments.Handlers
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly ICommentRepository _repository;

        public CreateCommentCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Comment
            {
                TaskId = request.TaskId,
                UserId = request.UserId,
                Content = request.Content,
                CreatedAt = request.CreatedAt
            };
            await _repository.AddAsync(comment);
            return comment.CommentId;
        }
    }
}
