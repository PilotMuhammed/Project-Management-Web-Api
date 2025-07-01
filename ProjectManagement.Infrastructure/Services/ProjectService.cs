using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.DTO.ProjectsDtos;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Domain.Models;
using ProjectManagement.Infrastructure.Data;
using System;

namespace ProjectManagement.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly AppDbContext _context;

        public ProjectService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProjectDto>> GetAllAsync()
        {
            return await _context.Projects.Select(p => new ProjectDto
            {
                ProjectId = p.ProjectId,
                Name = p.Name,
                Description = p.Description,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                StatusId = p.StatusId
            }).ToListAsync();
        }

        public async Task<ProjectDto> GetByIdAsync(int id)
        {
            var p = await _context.Projects.FindAsync(id);
            if (p == null) return null;

            return new ProjectDto
            {
                ProjectId = p.ProjectId,
                Name = p.Name,
                Description = p.Description,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                StatusId = p.StatusId
            };
        }

        public async Task<ProjectDto> CreateAsync(ProjectDto dto)
        {
            var p = new Project
            {
                Name = dto.Name,
                Description = dto.Description,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                StatusId = dto.StatusId
            };
            _context.Projects.Add(p);
            await _context.SaveChangesAsync();
            dto.ProjectId = p.ProjectId;
            return dto;
        }

        public async Task<ProjectDto> UpdateAsync(int id, ProjectDto dto)
        {
            var p = await _context.Projects.FindAsync(id);
            if (p == null) return null;
            p.Name = dto.Name;
            p.Description = dto.Description;
            p.StartDate = dto.StartDate;
            p.EndDate = dto.EndDate;
            p.StatusId = dto.StatusId;
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            var p = await _context.Projects.FindAsync(id);
            if (p != null)
            {
                _context.Projects.Remove(p);
                await _context.SaveChangesAsync();
            }
        }
    }
}
