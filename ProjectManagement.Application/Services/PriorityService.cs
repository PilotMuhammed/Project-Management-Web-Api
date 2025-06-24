using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.PriorityDtos;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Domain.Models;
using ProjectManagement.Infrastructure.Data;
using System;

namespace ProjectManagement.Application.Services
{
    public class PriorityService : IPriorityService
    {
        private readonly AppDbContext _context;
        public PriorityService(AppDbContext context) { _context = context; }

        public async Task<IEnumerable<PriorityDto>> GetAllAsync()
        {
            return await _context.Priorities
                .Select(p => new PriorityDto
                {
                    PriorityId = p.PriorityId,
                    Name = p.Name
                }).ToListAsync();
        }

        public async Task<PriorityDto> GetByIdAsync(int id)
        {
            var p = await _context.Priorities.FindAsync(id);
            if (p == null) return null;
            return new PriorityDto { PriorityId = p.PriorityId, Name = p.Name };
        }

        public async Task<PriorityDto> CreateAsync(PriorityDto dto)
        {
            var p = new Priority { Name = dto.Name };
            _context.Priorities.Add(p);
            await _context.SaveChangesAsync();
            dto.PriorityId = p.PriorityId;
            return dto;
        }

        public async Task<PriorityDto> UpdateAsync(int id, PriorityDto dto)
        {
            var p = await _context.Priorities.FindAsync(id);
            if (p == null) return null;
            p.Name = dto.Name;
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            var p = await _context.Priorities.FindAsync(id);
            if (p != null)
            {
                _context.Priorities.Remove(p);
                await _context.SaveChangesAsync();
            }
        }
    }
}
