using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.StatusDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Services.Interfaces
{
    public interface IStatusService
    {
        Task<IEnumerable<StatusDto>> GetAllAsync();
        Task<StatusDto> GetByIdAsync(int id);
        Task<StatusDto> CreateAsync(StatusDto dto);
        Task<StatusDto> UpdateAsync(int id, StatusDto dto);
        Task DeleteAsync(int id);
    }
}
