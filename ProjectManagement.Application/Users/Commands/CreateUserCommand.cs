using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ProjectManagement.Application.Users.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
    }
}
