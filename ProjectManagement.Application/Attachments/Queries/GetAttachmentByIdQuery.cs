using MediatR;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.AttachmentDtos;

namespace ProjectManagement.Application.Attachments.Queries
{
    public class GetAttachmentByIdQuery : IRequest<AttachmentDto>
    {
        public int AttachmentId { get; set; }
    }
}
