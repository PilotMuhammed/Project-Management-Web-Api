using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.StatusDtos;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Domain.Models;
using ProjectManagement.Infrastructure.Data;
using System;

namespace ProjectManagement.Application.Services
{
    public class StatusService : IStatusService
    {
        private readonly AppDbContext _context;
        public StatusService(AppDbContext context) { _context = context; }

        public async Task<IEnumerable<StatusDto>> GetAllAsync()
        {
            return await _context.Statuses
                .Select(s => new StatusDto
                {
                    StatusId = s.StatusId,
                    Name = s.Name
                }).ToListAsync();
        }

        public async Task<StatusDto> GetByIdAsync(int id)
        {
            var s = await _context.Statuses.FindAsync(id);
            if (s == null) return null;
            return new StatusDto { StatusId = s.StatusId, Name = s.Name };
        }

        public async Task<StatusDto> CreateAsync(StatusDto dto)
        {
            var s = new Status { Name = dto.Name };
            _context.Statuses.Add(s);
            await _context.SaveChangesAsync();
            dto.StatusId = s.StatusId;
            return dto;
        }

        public async Task<StatusDto> UpdateAsync(int id, StatusDto dto)
        {
            var s = await _context.Statuses.FindAsync(id);
            if (s == null) return null;
            s.Name = dto.Name;
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            var s = await _context.Statuses.FindAsync(id);
            if (s != null)
            {
                _context.Statuses.Remove(s);
                await _context.SaveChangesAsync();
            }
        }
    }
}
