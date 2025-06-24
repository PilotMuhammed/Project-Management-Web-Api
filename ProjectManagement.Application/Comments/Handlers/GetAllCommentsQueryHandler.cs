using MediatR;
using ProjectManagement.Application.Comments.Queries;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.CommentDtos;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Comments.Handlers
{
    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, IEnumerable<CommentDto>>
    {
        private readonly ICommentRepository _repository;

        public GetAllCommentsQueryHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CommentDto>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = await _repository.GetAllAsync();
            return comments.Select(c => new CommentDto
            {
                CommentId = c.CommentId,
                TaskId = c.TaskId,
                UserId = c.UserId,
                Content = c.Content,
                CreatedAt = c.CreatedAt
            }).ToList();
        }
    }
}
