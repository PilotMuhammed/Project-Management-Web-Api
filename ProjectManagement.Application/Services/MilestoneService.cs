using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.MilestoneDtos;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Domain.Models;
using ProjectManagement.Infrastructure.Data;
using System;

namespace ProjectManagement.Application.Services
{
    public class MilestoneService : IMilestoneService
    {
        private readonly AppDbContext _context;
        public MilestoneService(AppDbContext context) { _context = context; }

        public async Task<IEnumerable<MilestoneDto>> GetAllAsync()
        {
            return await _context.Milestones
                .Select(m => new MilestoneDto
                {
                    MilestoneId = m.MilestoneId,
                    ProjectId = m.ProjectId,
                    Name = m.Name,
                    DueDate = m.DueDate,
                    StatusId = m.StatusId
                }).ToListAsync();
        }

        public async Task<MilestoneDto> GetByIdAsync(int id)
        {
            var m = await _context.Milestones.FindAsync(id);
            if (m == null) return null;
            return new MilestoneDto
            {
                MilestoneId = m.MilestoneId,
                ProjectId = m.ProjectId,
                Name = m.Name,
                DueDate = m.DueDate,
                StatusId = m.StatusId
            };
        }

        public async Task<MilestoneDto> CreateAsync(MilestoneDto dto)
        {
            var m = new Milestone
            {
                ProjectId = dto.ProjectId,
                Name = dto.Name,
                DueDate = dto.DueDate,
                StatusId = dto.StatusId
            };
            _context.Milestones.Add(m);
            await _context.SaveChangesAsync();
            dto.MilestoneId = m.MilestoneId;
            return dto;
        }

        public async Task<MilestoneDto> UpdateAsync(int id, MilestoneDto dto)
        {
            var m = await _context.Milestones.FindAsync(id);
            if (m == null) return null;
            m.ProjectId = dto.ProjectId;
            m.Name = dto.Name;
            m.DueDate = dto.DueDate;
            m.StatusId = dto.StatusId;
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            var m = await _context.Milestones.FindAsync(id);
            if (m != null)
            {
                _context.Milestones.Remove(m);
                await _context.SaveChangesAsync();
            }
        }
    }
}
