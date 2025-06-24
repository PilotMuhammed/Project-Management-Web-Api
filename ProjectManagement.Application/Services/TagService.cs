using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.TagDtos;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Domain.Models;
using ProjectManagement.Infrastructure.Data;
using System;

namespace ProjectManagement.Application.Services
{
    public class TagService : ITagService
    {
        private readonly AppDbContext _context;
        public TagService(AppDbContext context) { _context = context; }

        public async Task<IEnumerable<TagDto>> GetAllAsync()
        {
            return await _context.Tags
                .Select(t => new TagDto
                {
                    TagId = t.TagId,
                    Name = t.Name
                }).ToListAsync();
        }

        public async Task<TagDto> GetByIdAsync(int id)
        {
            var t = await _context.Tags.FindAsync(id);
            if (t == null) return null;
            return new TagDto { TagId = t.TagId, Name = t.Name };
        }

        public async Task<TagDto> CreateAsync(TagDto dto)
        {
            var t = new Tag { Name = dto.Name };
            _context.Tags.Add(t);
            await _context.SaveChangesAsync();
            dto.TagId = t.TagId;
            return dto;
        }

        public async Task<TagDto> UpdateAsync(int id, TagDto dto)
        {
            var t = await _context.Tags.FindAsync(id);
            if (t == null) return null;
            t.Name = dto.Name;
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            var t = await _context.Tags.FindAsync(id);
            if (t != null)
            {
                _context.Tags.Remove(t);
                await _context.SaveChangesAsync();
            }
        }
    }
}
