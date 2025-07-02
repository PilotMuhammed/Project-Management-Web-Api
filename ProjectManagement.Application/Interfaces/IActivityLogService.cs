using ProjectManagement.Application.DTO.ActivityLogDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Services.Interfaces
{
    public interface IActivityLogService
    {
        Task<IEnumerable<ActivityLogDto>> GetAllAsync();
        Task<ActivityLogDto> GetByIdAsync(int id);
        Task<ActivityLogDto> CreateAsync(ActivityLogDto dto);
        Task<ActivityLogDto> UpdateAsync(int id, ActivityLogDto dto);
        Task DeleteAsync(int id);
    }
}
