using ApplicationShared.Dto.ProjectDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Entities;

namespace TaskManagementSystem.Application.IApplicationServices
{
    public interface IProjectAppService
    {

        Task<ProjectDto> GetProject(int id);
        Task<List<ProjectDto>> GetAllProjects();
        Task CreateProject(CreateProjectInput input);
        Task UpdateProject(UpdateProjectInput input);
        Task DeleteProject(int id);
    }
}
