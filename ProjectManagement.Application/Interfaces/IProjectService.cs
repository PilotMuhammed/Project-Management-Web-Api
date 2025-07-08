using ProjectManagement.Application.DTO.ProjectsDtos;
using ProjectManagement.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Services.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDto>> GetAllAsync();
        Task<ProjectDto> GetByIdAsync(int id);
        Task<ProjectDto> CreateAsync(ProjectDto dto);
        Task<ProjectDto> UpdateAsync(int id, ProjectDto dto);
        Task DeleteAsync(int id);
    }
}

