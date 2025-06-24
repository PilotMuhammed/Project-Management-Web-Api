using MediatR;

namespace ProjectManagement.Application.TaskTags.Commands
{
    public class DeleteTaskTagCommand : IRequest
    {
        public int TaskId { get; set; }
        public int TagId { get; set; }
    }
}
