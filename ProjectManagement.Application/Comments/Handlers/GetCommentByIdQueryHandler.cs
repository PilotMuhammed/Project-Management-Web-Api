using MediatR;
using ProjectManagement.Application.Comments.Queries;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.CommentDtos;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Comments.Handlers
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, CommentDto>
    {
        private readonly ICommentRepository _repository;

        public GetCommentByIdQueryHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommentDto> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetByIdAsync(request.CommentId);
            if (comment == null)
                return null;

            return new CommentDto
            {
                CommentId = comment.CommentId,
                TaskId = comment.TaskId,
                UserId = comment.UserId,
                Content = comment.Content,
                CreatedAt = comment.CreatedAt
            };
        }
    }
}
