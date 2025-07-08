using ProjectManagement.Application.DTO.TaskWorkDtos;
using ProjectManagement.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Services.Interfaces
{
    public interface ITaskWorkService
    {
        Task<IEnumerable<TaskWorkDto>> GetAllAsync();
        Task<TaskWorkDto> GetByIdAsync(int id);
        Task<TaskWorkDto> CreateAsync(TaskWorkDto dto);
        Task<TaskWorkDto> UpdateAsync(int id, TaskWorkDto dto);
        Task DeleteAsync(int id);
    }
}

