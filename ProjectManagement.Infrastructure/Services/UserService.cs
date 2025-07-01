using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.DTO.UserDtos;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Domain.Models;
using ProjectManagement.Infrastructure.Data;
using System;

namespace ProjectManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context) { _context = context; }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            return await _context.Users
                .Select(u => new UserDto
                {
                    UserId = u.UserId,
                    FullName = u.FullName,
                    Username = u.Username,
                    Email = u.Email,
                    PasswordHash = u.PasswordHash,
                    RoleId = u.RoleId
                }).ToListAsync();
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var u = await _context.Users.FindAsync(id);
            if (u == null) return null;
            return new UserDto
            {
                UserId = u.UserId,
                FullName = u.FullName,
                Username = u.Username,
                Email = u.Email,
                PasswordHash = u.PasswordHash,
                RoleId = u.RoleId
            };
        }

        public async Task<UserDto> CreateAsync(UserDto dto)
        {
            var u = new User
            {
                FullName = dto.FullName,
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = dto.PasswordHash,
                RoleId = dto.RoleId
            };
            _context.Users.Add(u);
            await _context.SaveChangesAsync();
            dto.UserId = u.UserId;
            return dto;
        }

        public async Task<UserDto> UpdateAsync(int id, UserDto dto)
        {
            var u = await _context.Users.FindAsync(id);
            if (u == null) return null;
            u.FullName = dto.FullName;
            u.Username = dto.Username;
            u.Email = dto.Email;
            u.PasswordHash = dto.PasswordHash;
            u.RoleId = dto.RoleId;
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            var u = await _context.Users.FindAsync(id);
            if (u != null)
            {
                _context.Users.Remove(u);
                await _context.SaveChangesAsync();
            }
        }
    }
}
