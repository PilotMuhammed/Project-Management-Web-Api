using ProjectManagement.Application.DTO.PriorityDtos;
using ProjectManagement.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Services.Interfaces
{
    public interface IPriorityService
    {
        Task<IEnumerable<PriorityDto>> GetAllAsync();
        Task<PriorityDto> GetByIdAsync(int id);
        Task<PriorityDto> CreateAsync(PriorityDto dto);
        Task<PriorityDto> UpdateAsync(int id, PriorityDto dto);
        Task DeleteAsync(int id);
    }
}

