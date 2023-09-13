using ApplicationShared.Dto.ProjectDto;
using ApplicationShared.Dto.TaskDto;
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
    public class ProjectAppService: IProjectAppService
    {
        private readonly IProjectRepository<Project, int> _projectRepository;
        private readonly IMapper _mapper;

        public ProjectAppService(IProjectRepository<Project, int> projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<ProjectDto> GetProject(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);

            var projectDto = _mapper.Map<ProjectDto>(project);
            return projectDto;

        }

        public async Task<List<ProjectDto>> GetAllProjects()
        {
            var project = await _projectRepository.GetAllAsync();
            var projectDtos = _mapper.Map<List<ProjectDto>>(project);
            return projectDtos;
        }

        public async Task CreateProject(CreateProjectInput input)
        {
            // Add any business logic or validation here before saving
            var existingEntity = await _projectRepository.FirstOrDefaultAsync(c => c.Name == input.Name);
            if (existingEntity != null)
            {
                throw new InvalidOperationException("A project with the same title already exists.");
            }

            var project = _mapper.Map<Project>(input);
            await _projectRepository.CreateAsync(project);
        }

        public async Task UpdateProject(UpdateProjectInput input)
        {
            // Add any business logic or validation here before updating

            var project = await _projectRepository.GetAsync(input.Id);

            //check if entity already exist
            var existingEntity = await _projectRepository.FirstOrDefaultAsync(c => c.Name == input.Name && c.Id != input.Id);
            if (existingEntity != null)
            {
                throw new InvalidOperationException("A project with the same title already exists.");
            }

            var projectInput = _mapper.Map<Project>(input);

            await _projectRepository.UpdateAsync(projectInput);
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

