using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.DTO.AttachmentDtos;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Domain.Models;
using ProjectManagement.Infrastructure.Data;
using System;

namespace ProjectManagement.Application.Services
{
    public class AttachmentService : IAttachmentService
    {
        private readonly AppDbContext _context;
        public AttachmentService(AppDbContext context) { _context = context; }

        public async Task<IEnumerable<AttachmentDto>> GetAllAsync()
        {
            return await _context.Attachments
                .Select(a => new AttachmentDto
                {
                    AttachmentId = a.AttachmentId,
                    TaskId = a.TaskId,
                    FileName = a.FileName,
                    FilePath = a.FilePath,
                    UploadedAt = a.UploadedAt
                }).ToListAsync();
        }

        public async Task<AttachmentDto> GetByIdAsync(int id)
        {
            var a = await _context.Attachments.FindAsync(id);
            if (a == null) return null;
            return new AttachmentDto
            {
                AttachmentId = a.AttachmentId,
                TaskId = a.TaskId,
                FileName = a.FileName,
                FilePath = a.FilePath,
                UploadedAt = a.UploadedAt
            };
        }

        public async Task<AttachmentDto> CreateAsync(AttachmentDto dto)
        {
            var a = new Attachment
            {
                TaskId = dto.TaskId,
                FileName = dto.FileName,
                FilePath = dto.FilePath,
                UploadedAt = dto.UploadedAt
            };
            _context.Attachments.Add(a);
            await _context.SaveChangesAsync();
            dto.AttachmentId = a.AttachmentId;
            return dto;
        }

        public async Task<AttachmentDto> UpdateAsync(int id, AttachmentDto dto)
        {
            var a = await _context.Attachments.FindAsync(id);
            if (a == null) return null;
            a.TaskId = dto.TaskId;
            a.FileName = dto.FileName;
            a.FilePath = dto.FilePath;
            a.UploadedAt = dto.UploadedAt;
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            var a = await _context.Attachments.FindAsync(id);
            if (a != null)
            {
                _context.Attachments.Remove(a);
                await _context.SaveChangesAsync();
            }
        }
    }
}
