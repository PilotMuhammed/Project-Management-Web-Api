using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ProjectManagement.Application.TaskWorks.Commands
{
    public class DeleteTaskWorkCommand : IRequest
    {
        public int TaskId { get; set; }
    }
}

