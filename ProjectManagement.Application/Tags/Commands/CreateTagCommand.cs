using MediatR;

namespace ProjectManagement.Application.Tags.Commands
{
    public class CreateTagCommand : IRequest<int>
    {
        public string? Name { get; set; }
    }
}
