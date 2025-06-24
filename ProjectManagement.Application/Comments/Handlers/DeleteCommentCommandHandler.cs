using MediatR;
using ProjectManagement.Application.Comments.Commands;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Comments.Handlers
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
    {
        private readonly ICommentRepository _repository;

        public DeleteCommentCommandHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.CommentId);
            return Unit.Value;
        }
    }
}
