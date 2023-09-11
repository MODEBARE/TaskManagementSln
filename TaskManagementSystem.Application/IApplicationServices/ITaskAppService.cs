using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Core.Entities;

namespace TaskManagementSystem.Application.IApplicationServices
{
    public interface ITaskAppService
    {
            Task<Tasks> GetTask(int id);
            Task<List<Tasks>> GetAllTasks();
            Task CreateTask(Tasks input);
            Task UpdateTask(Tasks input);
            Task DeleteTask(int id);
       
    }
}
