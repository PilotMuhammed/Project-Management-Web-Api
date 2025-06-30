using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.DTO.UserDtos
{
    public class CreateUserDto
    {
        public string? FullName { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public int RoleId { get; set; }
    }

    public class UpdateUserDto
    {
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public int RoleId { get; set; }
    }

    public class UserDto
    {
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? RoleName { get; set; }
        public string? PasswordHash { get; set; }
        public int RoleId { get; set; }
    }
}

