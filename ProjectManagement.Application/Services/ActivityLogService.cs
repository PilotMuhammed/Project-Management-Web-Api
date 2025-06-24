using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.DTO;
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
                    ActivityLogId = a.ActivityLogId,
                    UserId = a.UserId,
                    Action = a.Action,
                    Timestamp = a.Timestamp
                }).ToListAsync();
        }

        public async Task<ActivityLogDto> GetByIdAsync(int id)
        {
            var a = await _context.ActivityLogs.FindAsync(id);
            if (a == null) return null;
            return new ActivityLogDto
            {
                ActivityLogId = a.ActivityLogId,
                UserId = a.UserId,
                Action = a.Action,
                Timestamp = a.Timestamp
            };
        }

        public async Task<ActivityLogDto> CreateAsync(ActivityLogDto dto)
        {
            var a = new ActivityLog
            {
                UserId = dto.UserId,
                Action = dto.Action,
                Timestamp = dto.Timestamp
            };
            _context.ActivityLogs.Add(a);
            await _context.SaveChangesAsync();
            dto.ActivityLogId = a.ActivityLogId;
            return dto;
        }

        public async Task<ActivityLogDto> UpdateAsync(int id, ActivityLogDto dto)
        {
            var a = await _context.ActivityLogs.FindAsync(id);
            if (a == null) return null;
            a.UserId = dto.UserId;
            a.Action = dto.Action;
            a.Timestamp = dto.Timestamp;
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
