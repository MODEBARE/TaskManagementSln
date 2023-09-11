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

        Task<Project> GetProject(int id);
        Task<List<Project>> GetAllProjects();
        Task CreateProject(Project input);
        Task UpdateProject(Project input);
        Task DeleteProject(int id);
    }
}
