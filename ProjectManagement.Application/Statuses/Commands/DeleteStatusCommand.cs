using MediatR;

namespace ProjectManagement.Application.Statuses.Commands
{
    public class DeleteStatusCommand : IRequest
    {
        public int StatusId { get; set; }
    }
}
