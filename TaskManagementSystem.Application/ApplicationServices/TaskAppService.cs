using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.IApplicationServices;
using TaskManagementSystem.Core.Entities;
using TaskManagementSystem.Core.Interfaces;

namespace TaskManagementSystem.Application.ApplicationServices
{
    public class TaskAppService : ITaskAppService
    {
        private readonly ITaskRepository<Tasks, int> _taskRepository;

        public TaskAppService(ITaskRepository<Tasks, int> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<Tasks> GetTask(int id)
        {
            return await _taskRepository.GetByIdAsync(id);
        }

        public async Task<List<Tasks>> GetAllTasks()
        {
            return await _taskRepository.GetAllAsync();
        }

        public async Task CreateTask(Tasks task)
        {
            // Add any business logic or validation here before saving
            var existingEntity = await _taskRepository.FirstOrDefaultAsync(c => c.Title == task.Title);
            if (existingEntity != null)
            {
                throw new InvalidOperationException("A task with the same title already exists.");
            }
            await _taskRepository.CreateAsync(task);
        }

        public async Task UpdateTask(Tasks input)
        {
            // Add any business logic or validation here before updating

            var task = await _taskRepository.GetAsync(input.Id);

            //check if entity already exist
            var existingEntity = await _taskRepository.FirstOrDefaultAsync(c => c.Title == input.Title && c.Id != input.Id);
            if (existingEntity != null)
            {
                throw new InvalidOperationException("A task with the same title already exists.");
            }

            await _taskRepository.UpdateAsync(task);
        }

        public async Task DeleteTask(int id)
        {
            // Add any business logic or validation here before deleting
            var existingEntity = await _taskRepository.FirstOrDefaultAsync(c => c.Id == id);
            if (existingEntity == null)
            {
                throw new InvalidOperationException("A task with Id not exists.");
            }

            await _taskRepository.DeleteAsync(id);
        }
    }

}
