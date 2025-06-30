using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ProjectManagement.Application.TaskWorks.Commands
{
    public class CreateTaskWorkCommand : IRequest<int>
    {
        public int ProjectId { get; set; }
        public int AssignedUserId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }
    }
}
