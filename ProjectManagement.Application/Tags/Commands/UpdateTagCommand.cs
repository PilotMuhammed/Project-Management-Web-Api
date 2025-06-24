using MediatR;

namespace ProjectManagement.Application.Tags.Commands
{
    public class UpdateTagCommand : IRequest
    {
        public int TagId { get; set; }
        public string Name { get; set; }
    }
}
