using MediatR;
using ProjectManagement.Application.Attachments.Commands;
using ProjectManagement.Domain.Interfaces;

namespace ProjectManagement.Application.Attachments.Handlers
{
    public class DeleteAttachmentCommandHandler : IRequestHandler<DeleteAttachmentCommand>
    {
        private readonly IAttachmentRepository _repository;

        public DeleteAttachmentCommandHandler(IAttachmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteAttachmentCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.AttachmentId);
            return Unit.Value;
        }
    }
}
