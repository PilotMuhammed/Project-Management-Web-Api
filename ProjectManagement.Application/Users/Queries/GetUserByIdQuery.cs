using MediatR;
using ProjectManagement.Application.DTO.UserDtos;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Users.Queries
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public int UserId { get; set; }
    }
}
