using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Application.ApplicationServices;
using TaskManagementSystem.Application.IApplicationServices;
using TaskManagementSystem.Core.Entities;
using TaskManagementSystem.Core.Interfaces;

namespace TaskManagementSystem.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectAppService _projectAppService;
        private readonly ITaskRepository<Task, int> _taskRepository;
        private readonly IProjectRepository<Project, int> _projectRepository;

        public ProjectController(IProjectAppService projectAppService,
            ITaskRepository<Task, int> taskRepository,
            IProjectRepository<Project, int> projectRepository
            )
        {
            _projectAppService = projectAppService;
            _projectRepository = projectRepository;
            _taskRepository = taskRepository;


        }

        [HttpGet]
        public async Task<ActionResult<List<Project>>> GetAllProjects()
        {
            var project = await _projectAppService.GetAllProjects();
            return Ok(project);
        }

        [HttpGet("{projectId}")]
        public async Task<ActionResult<Project>> GetProject(int projectId)
        {
            var project = await _projectAppService.GetProject(projectId);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] Project input)
        {
            if (input == null)
            {
                return BadRequest();
            }

            await _projectAppService.CreateProject(input);
            return CreatedAtAction(nameof(GetProject), new { taskId = input.Id }, input);
        }

        [HttpPut("{projectId}")]
        public async Task<IActionResult> UpdateProject(int projectId, [FromBody] Project input)
        {
            if (input == null || input.Id != projectId)
            {
                return BadRequest();
            }

            await _projectAppService.UpdateProject(input);
            return NoContent();
        }

        [HttpDelete("{projectId}")]
        public async Task<IActionResult> DeleteProject(int projectId)
        {
            await _projectAppService.DeleteProject(projectId);
            return NoContent();
        }

        // Tasks Controller
        // PUT: api/tasks/1/assign-to-project/2
        [HttpPut("{taskId}/assign-to-project/{projectId}")]
        public async Task<IActionResult> AssignTaskToProject(int taskId, int projectId)
        {
            var task = await _taskRepository.GetByIdAsync(taskId);
            var project = await _projectRepository.GetByIdAsync(projectId);

            if (task == null || project == null)
            {
                return NotFound();
            }

            project.Tasks = task;
            project.Tasks.Id = task.Id;
            await _projectRepository.UpdateAsync(project);

            return NoContent();
        }

        // DELETE: api/tasks/1/remove-from-project
        [HttpDelete("{taskId}/remove-from-project/{projectId}")]
        public async Task<IActionResult> RemoveTaskFromProject(int taskId, int projectId)
        {
            var project = await _projectRepository.GetByIdAsync(projectId);

            if (project == null)
            {
                return NotFound("Project not found");
            }

            // Check if the task is associated with the project
            if (project.TaskId != taskId)
            {
                return NotFound("Task not associated with the project");
            }

            // Remove the task from the project
            project.TaskId = null;

            await _projectRepository.UpdateAsync(project);

            return NoContent();
        }



    }

}
