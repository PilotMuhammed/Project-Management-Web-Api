using MediatR;
using ProjectManagement.Application.Attachments.Queries;
using ProjectManagement.Application.DTO.AttachmentDtos;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Attachments.Handlers
{
    public class GetAllAttachmentsQueryHandler : IRequestHandler<GetAllAttachmentsQuery, IEnumerable<AttachmentDto>>
    {
        private readonly IAttachmentRepository _repository;

        public GetAllAttachmentsQueryHandler(IAttachmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AttachmentDto>> Handle(GetAllAttachmentsQuery request, CancellationToken cancellationToken)
        {
            var attachments = await _repository.GetAllAsync();
            return attachments.Select(a => new AttachmentDto
            {
                AttachmentId = a.AttachmentId,
                TaskId = a.TaskId,
                FileName = a.FileName,
                FilePath = a.FilePath,
                UploadedAt = a.UploadedAt
            }).ToList();
        }
    }
}
