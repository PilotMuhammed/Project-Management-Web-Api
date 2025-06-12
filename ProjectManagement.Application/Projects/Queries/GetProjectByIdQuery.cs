using MediatR;
using ProjectManagement.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Projects.Queries
{
    public class GetProjectByIdQuery : IRequest<ProjectDto>
    {
        public int ProjectId { get; set; }
    }
}
