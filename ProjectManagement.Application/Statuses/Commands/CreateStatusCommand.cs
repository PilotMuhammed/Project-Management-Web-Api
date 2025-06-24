using MediatR;

namespace ProjectManagement.Application.Statuses.Commands
{
    public class CreateStatusCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
