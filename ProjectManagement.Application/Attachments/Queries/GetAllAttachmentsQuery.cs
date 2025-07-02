using MediatR;
using ProjectManagement.Application.DTO.AttachmentDtos;

namespace ProjectManagement.Application.Attachments.Queries
{
    public class GetAllAttachmentsQuery : IRequest<IEnumerable<AttachmentDto>>
    {
    }
}
