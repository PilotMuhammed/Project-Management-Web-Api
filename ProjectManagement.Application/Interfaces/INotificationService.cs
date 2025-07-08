using ProjectManagement.Application.DTO.NotificationDtos;
using ProjectManagement.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Services.Interfaces
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationDto>> GetAllAsync();
        Task<NotificationDto> GetByIdAsync(int id);
        Task<NotificationDto> CreateAsync(NotificationDto dto);
        Task<NotificationDto> UpdateAsync(int id, NotificationDto dto);
        Task DeleteAsync(int id);
    }
}

