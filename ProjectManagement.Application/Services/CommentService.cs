using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.CommentDtos;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Domain.Models;
using ProjectManagement.Infrastructure.Data;
using System;

namespace ProjectManagement.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly AppDbContext _context;
        public CommentService(AppDbContext context) { _context = context; }

        public async Task<IEnumerable<CommentDto>> GetAllAsync()
        {
            return await _context.Comments
                .Select(c => new CommentDto
                {
                    CommentId = c.CommentId,
                    TaskId = c.TaskId,
                    UserId = c.UserId,
                    Content = c.Content,
                    CreatedAt = c.CreatedAt
                }).ToListAsync();
        }

        public async Task<CommentDto> GetByIdAsync(int id)
        {
            var c = await _context.Comments.FindAsync(id);
            if (c == null) return null;
            return new CommentDto
            {
                CommentId = c.CommentId,
                TaskId = c.TaskId,
                UserId = c.UserId,
                Content = c.Content,
                CreatedAt = c.CreatedAt
            };
        }

        public async Task<CommentDto> CreateAsync(CommentDto dto)
        {
            var c = new Comment
            {
                TaskId = dto.TaskId,
                UserId = dto.UserId,
                Content = dto.Content,
                CreatedAt = dto.CreatedAt
            };
            _context.Comments.Add(c);
            await _context.SaveChangesAsync();
            dto.CommentId = c.CommentId;
            return dto;
        }

        public async Task<CommentDto> UpdateAsync(int id, CommentDto dto)
        {
            var c = await _context.Comments.FindAsync(id);
            if (c == null) return null;
            c.TaskId = dto.TaskId;
            c.UserId = dto.UserId;
            c.Content = dto.Content;
            c.CreatedAt = dto.CreatedAt;
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            var c = await _context.Comments.FindAsync(id);
            if (c != null)
            {
                _context.Comments.Remove(c);
                await _context.SaveChangesAsync();
            }
        }
    }
}
