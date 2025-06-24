using MediatR;
using ProjectManagement.Application.Comments.Commands;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Comments.Handlers
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand>
    {
        private readonly ICommentRepository _repository;

        public UpdateCommentCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetByIdAsync(request.CommentId);
            if (comment == null)
                throw new KeyNotFoundException("Comment not found");

            comment.TaskId = request.TaskId;
            comment.UserId = request.UserId;
            comment.Content = request.Content;
            comment.CreatedAt = request.CreatedAt;

            await _repository.UpdateAsync(comment);
            return Unit.Value;
        }
    }
}
