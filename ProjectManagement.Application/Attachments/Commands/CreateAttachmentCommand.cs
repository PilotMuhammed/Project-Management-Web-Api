using MediatR;

namespace ProjectManagement.Application.Attachments.Commands
{
    public class CreateAttachmentCommand : IRequest<int>
    {
        public int TaskId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
