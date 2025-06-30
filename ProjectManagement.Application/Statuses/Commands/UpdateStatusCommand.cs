using MediatR;

namespace ProjectManagement.Application.Statuses.Commands
{
    public class UpdateStatusCommand : IRequest
    {
        public int StatusId { get; set; }
        public string? Name { get; set; }
    }
}
