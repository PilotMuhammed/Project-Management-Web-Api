using MediatR;
using ProjectManagement.Application.Attachments.Queries;
using ProjectManagement.Application.DTO.AttachmentDtos;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Attachments.Handlers
{
    public class GetAttachmentByIdQueryHandler : IRequestHandler<GetAttachmentByIdQuery, AttachmentDto>
    {
        private readonly IAttachmentRepository _repository;

        public GetAttachmentByIdQueryHandler(IAttachmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<AttachmentDto> Handle(GetAttachmentByIdQuery request, CancellationToken cancellationToken)
        {
            var attachment = await _repository.GetByIdAsync(request.AttachmentId);
            if (attachment == null)
                return null;

            return new AttachmentDto
            {
                AttachmentId = attachment.AttachmentId,
                TaskId = attachment.TaskId,
                FileName = attachment.FileName,
                FilePath = attachment.FilePath,
                UploadedAt = attachment.UploadedAt
            };
        }
    }
}
