using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ProjectManagement.Application.Users.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public int UserId { get; set; }
    }
}
