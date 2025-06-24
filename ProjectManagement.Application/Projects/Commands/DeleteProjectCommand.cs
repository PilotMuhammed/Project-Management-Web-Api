using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Projects.Commands
{
    public class DeleteProjectCommand : IRequest
    {
        public int ProjectId { get; set; }
    }
}
