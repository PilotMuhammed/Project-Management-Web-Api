using ProjectManagement.Application.DTO.MilestoneDtos;
using ProjectManagement.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Services.Interfaces
{
    public interface IMilestoneService
    {
        Task<IEnumerable<MilestoneDto>> GetAllAsync();
        Task<MilestoneDto> GetByIdAsync(int id);
        Task<MilestoneDto> CreateAsync(MilestoneDto dto);
        Task<MilestoneDto> UpdateAsync(int id, MilestoneDto dto);
        Task DeleteAsync(int id);
    }
}
