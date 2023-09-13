using ApplicationShared.Dto.TaskDto;
using ApplicationSharedDto.TaskDto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.Application.IApplicationServices;
using TaskManagementSystem.Core.Entities;
using TaskManagementSystem.Infrastucture.Interfaces;

namespace TaskManagementSystem.Application.ApplicationServices
{
    public class TaskAppService : ITaskAppService
    {
        private readonly ITaskRepository<Tasks, int> _taskRepository;
        private readonly IMapper _mapper;

        public TaskAppService(ITaskRepository<Tasks, int> taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<TaskDto> GetTask(int id)
        {
            var task= await _taskRepository.GetByIdAsync(id);
            var taskDtos = _mapper.Map<TaskDto>(task);
            return taskDtos;

        }

        public async Task<List<TaskDto>> GetAllTasks()
        {
            var task = await _taskRepository.GetAllAsync();
            var taskDtos = _mapper.Map<List<TaskDto>>(task);
            return taskDtos;
        }

        public async Task CreateTask(CreateTaskInput input)
        {
            //  business logic/validation 
            var existingEntity = await _taskRepository.FirstOrDefaultAsync(c => c.Title == input.Title);
            if (existingEntity != null)
            {
                throw new InvalidOperationException("A task with the same title already exists.");
            }

          
            var task = _mapper.Map<Tasks>(input);
            await _taskRepository.CreateAsync(task);
            
        }

        public async Task UpdateTask(UpdateTaskInput input)
        {
            // Add business logic/validation

            var task = await _taskRepository.GetAsync(input.Id);

            //check if entity already exist
            var existingEntity = await _taskRepository.FirstOrDefaultAsync(c => c.Title == input.Title && c.Id != input.Id);
            if (existingEntity != null)
            {
                throw new InvalidOperationException("A task with the same title already exists.");
            }

            var tasks = _mapper.Map<Tasks>(input);

            await _taskRepository.UpdateAsync(tasks);
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
