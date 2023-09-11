using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Application.IApplicationServices;
using TaskManagementSystem.Core.Entities;
using TaskManagementSystem.Core.Entities.Enums;
using TaskManagementSystem.Core.Interfaces;

namespace TaskManagementSystem.Web.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskAppService _taskAppService;
        private readonly ITaskRepository<Tasks, int> _taskRepository;
        private readonly IProjectRepository<Project, int> _projectRepository;

        public TasksController(ITaskAppService taskAppService, 
            ITaskRepository<Tasks, int> taskRepository,
            IProjectRepository<Project, int> projectRepository)
        {
            _taskAppService = taskAppService;
            _taskRepository = taskRepository;
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Tasks>>> GetAllTasks()
        {
            var tasks = await _taskAppService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{taskId}")]
        public async Task<ActionResult<Tasks>> GetTask(int taskId)
        {
            var task = await _taskAppService.GetTask(taskId);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] Tasks input)
        {
            if (input == null)
            {
                return BadRequest();
            }

            await _taskAppService.CreateTask(input);
            return CreatedAtAction(nameof(GetTask), new { taskId = input.Id }, input);
        }

        [HttpPut("{taskId}")]
        public async Task<IActionResult> UpdateTask(int taskId, [FromBody] Tasks input)
        {
            if (input == null || input.Id != taskId)
            {
                return BadRequest();
            }

            await _taskAppService.UpdateTask(input);
            return NoContent();
        }

        [HttpDelete("{taskId}")]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            await _taskAppService.DeleteTask(taskId);
            return NoContent();
        }

        // Tasks Controller
        // GET: api/tasks/filter?status=pending&priority=high
        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<Tasks>>> GetTasksByStatusOrPriority(
            [FromQuery] Status status,
            [FromQuery] Priority priority)
        {
            IQueryable<Tasks> query = _taskRepository.GetAll()
                .Where(c=> c.Status == status && c.Priority == priority);

           
            var tasks = await query.ToListAsync();

            return tasks;
        }

        // Tasks Controller
        // GET: api/tasks/week
        [HttpGet("week")]
        public async Task<ActionResult<IEnumerable<Tasks>>> GetTasksDueForCurrentWeek()
        {
            DateTime today = DateTime.Today;
            DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek);
            DateTime endOfWeek = startOfWeek.AddDays(7);

            var tasks = await _taskRepository.GetAll()
                .Where(t => t.DueDate >= startOfWeek && t.DueDate <= endOfWeek)
                .ToListAsync();

            return tasks;
        }


    }
}
