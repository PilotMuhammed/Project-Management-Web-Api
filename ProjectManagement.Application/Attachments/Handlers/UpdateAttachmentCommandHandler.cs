using MediatR;
using ProjectManagement.Application.Attachments.Commands;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Attachments.Handlers
{
    public class UpdateAttachmentCommandHandler : IRequestHandler<UpdateAttachmentCommand>
    {
        private readonly IAttachmentRepository _repository;

        public UpdateAttachmentCommandHandler(IAttachmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateAttachmentCommand request, CancellationToken cancellationToken)
        {
            var attachment = await _repository.GetByIdAsync(request.AttachmentId);
            if (attachment == null)
                throw new KeyNotFoundException("Attachment not found");

            attachment.TaskId = request.TaskId;
            attachment.FileName = request.FileName;
            attachment.FilePath = request.FilePath;
            attachment.UploadedAt = request.UploadedAt;

            await _repository.UpdateAsync(attachment);
            return Unit.Value;
        }
    }
}
