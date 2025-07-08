using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.DTO
{
    public class LoginRequestDto
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }

    public class LoginResponseDto
    {
        public string? Token { get; set; }
        public string? Username { get; set; }
        public string? Role { get; set; }
    }

    public class RegisterRequestDto
    {
        public string? FullName { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; } 
    }

    public class RegisterResponseDto
    {
        public int UserId { get; set; }
        public string? Username { get; set; }
    }
}

