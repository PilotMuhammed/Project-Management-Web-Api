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
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _repository;

        public GetUserByIdQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.UserId);
            if (user == null)
                return null;

            return new UserDto
            {
                UserId = user.UserId,
                FullName = user.FullName,
                Username = user.Username,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                RoleId = user.RoleId
            };
        }
    }
}

