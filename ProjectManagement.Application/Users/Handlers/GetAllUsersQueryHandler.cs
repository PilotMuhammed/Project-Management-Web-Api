using MediatR;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.UserDtos;
using ProjectManagement.Application.Users.Queries;
using ProjectManagement.Domain.Interfaces;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Users.Handlers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
    {
        private readonly IUserRepository _repository;

        public GetAllUsersQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllAsync();
            return users.Select(u => new UserDto
            {
                UserId = u.UserId,
                FullName = u.FullName,
                Username = u.Username,
                Email = u.Email,
                PasswordHash = u.PasswordHash,
                RoleId = u.RoleId
            }).ToList();
        }
    }
}
