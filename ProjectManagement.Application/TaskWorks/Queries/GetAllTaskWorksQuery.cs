using MediatR;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.TaskWorkDtos;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.TaskWorks.Queries
{
    public class GetAllTaskWorksQuery : IRequest<IEnumerable<TaskWorkDto>>
    {
    }
}
