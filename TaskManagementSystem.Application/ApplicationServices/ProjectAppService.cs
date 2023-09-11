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
    public class ProjectAppService: IProjectAppService
    {
        private readonly IProjectRepository<Project, int> _projectRepository;

        public ProjectAppService(IProjectRepository<Project, int> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Project> GetProject(int id)
        {
            return await _projectRepository.GetByIdAsync(id);
        }

        public async Task<List<Project>> GetAllProjects()
        {
            return await _projectRepository.GetAllAsync();
        }

        public async Task CreateProject(Project project)
        {
            // Add any business logic or validation here before saving
            var existingEntity = await _projectRepository.FirstOrDefaultAsync(c => c.Name == project.Name);
            if (existingEntity != null)
            {
                throw new InvalidOperationException("A project with the same title already exists.");
            }
            await _projectRepository.CreateAsync(project);
        }

        public async Task UpdateProject(Project input)
        {
            // Add any business logic or validation here before updating

            var project = await _projectRepository.GetAsync(input.Id);

            //check if entity already exist
            var existingEntity = await _projectRepository.FirstOrDefaultAsync(c => c.Name == input.Name && c.Id != input.Id);
            if (existingEntity != null)
            {
                throw new InvalidOperationException("A project with the same title already exists.");
            }

            await _projectRepository.UpdateAsync(project);
        }   

        public async Task DeleteProject(int id)
        {
            // Add any business logic or validation here before deleting
            var existingEntity = await _projectRepository.FirstOrDefaultAsync(c => c.Id == id);
            if (existingEntity == null)
            {
                throw new InvalidOperationException("A project with Id not exists.");
            }

            await _projectRepository.DeleteAsync(id);
        }

        }

    }

