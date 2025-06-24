using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.RoleDtos;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Domain.Models;
using ProjectManagement.Infrastructure.Data;
using System;

namespace ProjectManagement.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly AppDbContext _context;
        public RoleService(AppDbContext context) { _context = context; }

        public async Task<IEnumerable<RoleDto>> GetAllAsync()
        {
            return await _context.Roles
                .Select(r => new RoleDto
                {
                    RoleId = r.RoleId,
                    Name = r.Name
                }).ToListAsync();
        }

        public async Task<RoleDto> GetByIdAsync(int id)
        {
            var r = await _context.Roles.FindAsync(id);
            if (r == null) return null;
            return new RoleDto { RoleId = r.RoleId, Name = r.Name };
        }

        public async Task<RoleDto> CreateAsync(RoleDto dto)
        {
            var r = new Role { Name = dto.Name };
            _context.Roles.Add(r);
            await _context.SaveChangesAsync();
            dto.RoleId = r.RoleId;
            return dto;
        }

        public async Task<RoleDto> UpdateAsync(int id, RoleDto dto)
        {
            var r = await _context.Roles.FindAsync(id);
            if (r == null) return null;
            r.Name = dto.Name;
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            var r = await _context.Roles.FindAsync(id);
            if (r != null)
            {
                _context.Roles.Remove(r);
                await _context.SaveChangesAsync();
            }
        }
    }
}
