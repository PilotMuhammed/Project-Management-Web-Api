using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.TaskWorkDtos;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Domain.Models;
using ProjectManagement.Infrastructure.Data;
using System;

namespace ProjectManagement.Application.Services
{
    public class TaskWorkService : ITaskWorkService
    {
        private readonly AppDbContext _context;
        public TaskWorkService(AppDbContext context) { _context = context; }

        public async Task<IEnumerable<TaskWorkDto>> GetAllAsync()
        {
            return await _context.TaskWorks
                .Select(t => new TaskWorkDto
                {
                    TaskId = t.TaskId,
                    ProjectId = t.ProjectId,
                    AssignedUserId = t.AssignedUserId,
                    Title = t.Title,
                    Description = t.Description,
                    StartDate = t.StartDate,
                    EndDate = t.EndDate,
                    StatusId = t.StatusId,
                    PriorityId = t.PriorityId
                }).ToListAsync();
        }

        public async Task<TaskWorkDto> GetByIdAsync(int id)
        {
            var t = await _context.TaskWorks.FindAsync(id);
            if (t == null) return null;
            return new TaskWorkDto
            {
                TaskId = t.TaskId,
                ProjectId = t.ProjectId,
                AssignedUserId = t.AssignedUserId,
                Title = t.Title,
                Description = t.Description,
                StartDate = t.StartDate,
                EndDate = t.EndDate,
                StatusId = t.StatusId,
                PriorityId = t.PriorityId
            };
        }

        public async Task<TaskWorkDto> CreateAsync(TaskWorkDto dto)
        {
            var t = new TaskWork
            {
                ProjectId = dto.ProjectId,
                AssignedUserId = dto.AssignedUserId,
                Title = dto.Title,
                Description = dto.Description,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                StatusId = dto.StatusId,
                PriorityId = dto.PriorityId
            };
            _context.TaskWorks.Add(t);
            await _context.SaveChangesAsync();
            dto.TaskId = t.TaskId;
            return dto;
        }

        public async Task<TaskWorkDto> UpdateAsync(int id, TaskWorkDto dto)
        {
            var t = await _context.TaskWorks.FindAsync(id);
            if (t == null) return null;
            t.ProjectId = dto.ProjectId;
            t.AssignedUserId = dto.AssignedUserId;
            t.Title = dto.Title;
            t.Description = dto.Description;
            t.StartDate = dto.StartDate;
            t.EndDate = dto.EndDate;
            t.StatusId = dto.StatusId;
            t.PriorityId = dto.PriorityId;
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            var t = await _context.TaskWorks.FindAsync(id);
            if (t != null)
            {
                _context.TaskWorks.Remove(t);
                await _context.SaveChangesAsync();
            }
        }
    }
}
