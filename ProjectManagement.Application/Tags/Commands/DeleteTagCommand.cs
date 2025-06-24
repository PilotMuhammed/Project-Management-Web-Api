using MediatR;

namespace ProjectManagement.Application.Tags.Commands
{
    public class DeleteTagCommand : IRequest
    {
        public int TagId { get; set; }
    }
}
