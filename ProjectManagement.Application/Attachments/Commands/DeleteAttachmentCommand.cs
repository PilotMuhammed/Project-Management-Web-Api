using MediatR;

namespace ProjectManagement.Application.Attachments.Commands
{
    public class DeleteAttachmentCommand : IRequest
    {
        public int AttachmentId { get; set; }
    }
}
