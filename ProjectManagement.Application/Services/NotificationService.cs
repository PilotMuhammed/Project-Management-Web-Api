using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.NotificationDtos;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Domain.Models;
using ProjectManagement.Infrastructure.Data;
using System;

namespace ProjectManagement.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly AppDbContext _context;
        public NotificationService(AppDbContext context) { _context = context; }

        public async Task<IEnumerable<NotificationDto>> GetAllAsync()
        {
            return await _context.Notifications
                .Select(n => new NotificationDto
                {
                    NotificationId = n.NotificationId,
                    UserId = n.UserId,
                    Content = n.Content,
                    DateSent = n.DateSent,
                    IsRead = n.IsRead
                }).ToListAsync();
        }

        public async Task<NotificationDto> GetByIdAsync(int id)
        {
            var n = await _context.Notifications.FindAsync(id);
            if (n == null) return null;
            return new NotificationDto
            {
                NotificationId = n.NotificationId,
                UserId = n.UserId,
                Content = n.Content,
                DateSent = n.DateSent,
                IsRead = n.IsRead
            };
        }

        public async Task<NotificationDto> CreateAsync(NotificationDto dto)
        {
            var n = new Notification
            {
                UserId = dto.UserId,
                Content = dto.Content,
                DateSent = dto.DateSent,
                IsRead = dto.IsRead
            };
            _context.Notifications.Add(n);
            await _context.SaveChangesAsync();
            dto.NotificationId = n.NotificationId;
            return dto;
        }

        public async Task<NotificationDto> UpdateAsync(int id, NotificationDto dto)
        {
            var n = await _context.Notifications.FindAsync(id);
            if (n == null) return null;
            n.UserId = dto.UserId;
            n.Content = dto.Content;
            n.DateSent = dto.DateSent;
            n.IsRead = dto.IsRead;
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            var n = await _context.Notifications.FindAsync(id);
            if (n != null)
            {
                _context.Notifications.Remove(n);
                await _context.SaveChangesAsync();
            }
        }
    }
}
