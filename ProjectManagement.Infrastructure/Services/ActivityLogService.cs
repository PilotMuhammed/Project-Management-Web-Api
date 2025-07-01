using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.DTO.ActivityLogDtos;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Domain.Models;
using ProjectManagement.Infrastructure.Data;
using System;

namespace ProjectManagement.Application.Services
{
    public class ActivityLogService : IActivityLogService
    {
        private readonly AppDbContext _context;
        public ActivityLogService(AppDbContext context) { _context = context; }

        public async Task<IEnumerable<ActivityLogDto>> GetAllAsync()
        {
            return await _context.ActivityLogs
                .Select(a => new ActivityLogDto
                {
                    ActivityId = a.ActivityLogId,
                    UserId = a.UserId,
                    Action = a.Action,
                    CreatedAt = a.CreatedAt
                }).ToListAsync();
        }

        public async Task<ActivityLogDto> GetByIdAsync(int id)
        {
            var a = await _context.ActivityLogs.FindAsync(id);
            if (a == null) return null;
            return new ActivityLogDto
            {
                ActivityId = a.ActivityLogId,
                UserId = a.UserId,
                Action = a.Action,
                CreatedAt = a.CreatedAt
            };
        }

        public async Task<ActivityLogDto> CreateAsync(ActivityLogDto dto)
        {
            var a = new ActivityLog
            {
                UserId = dto.UserId,
                Action = dto.Action,
                CreatedAt = dto.CreatedAt
            };
            _context.ActivityLogs.Add(a);
            await _context.SaveChangesAsync();
            dto.ActivityId = a.ActivityLogId;
            return dto;
        }

        public async Task<ActivityLogDto> UpdateAsync(int id, ActivityLogDto dto)
        {
            var a = await _context.ActivityLogs.FindAsync(id);
            if (a == null) return null;
            a.UserId = dto.UserId;
            a.Action = dto.Action;
            a.CreatedAt = dto.CreatedAt;
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            var a = await _context.ActivityLogs.FindAsync(id);
            if (a != null)
            {
                _context.ActivityLogs.Remove(a);
                await _context.SaveChangesAsync();
            }
        }
    }
}
