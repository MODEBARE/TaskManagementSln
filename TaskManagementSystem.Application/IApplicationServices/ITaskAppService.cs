using ApplicationShared.Dto.TaskDto;
using ApplicationSharedDto.TaskDto;
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
            Task<TaskDto> GetTask(int id);
            Task<List<TaskDto>> GetAllTasks();
            Task CreateTask(CreateTaskInput input);
            Task UpdateTask(UpdateTaskInput input);
            Task DeleteTask(int id);
       
    }
}
