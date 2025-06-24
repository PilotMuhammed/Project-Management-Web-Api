using MediatR;
using ProjectManagement.Application.Attachments.Commands;
using ProjectManagement.Domain.Models;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Attachments.Handlers
{
    public class CreateAttachmentCommandHandler : IRequestHandler<CreateAttachmentCommand, int>
    {
        private readonly IAttachmentRepository _repository;

        public CreateAttachmentCommandHandler(IAttachmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateAttachmentCommand request, CancellationToken cancellationToken)
        {
            var attachment = new Attachment
            {
                TaskId = request.TaskId,
                FileName = request.FileName,
                FilePath = request.FilePath,
                UploadedAt = request.UploadedAt
            };
            await _repository.AddAsync(attachment);
            return attachment.AttachmentId;
        }
    }
}
