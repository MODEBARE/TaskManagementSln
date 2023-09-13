using ApplicationShared.Dto.TaskDto;
using ApplicationSharedDto.TaskDto;
using AutoMapper;

namespace TaskManagementSystem.Web.CustomDtoMapper
{
    public class TaskProfile: Profile
    {
        public TaskProfile()
        {
            CreateMap<Task, TaskDto>().ReverseMap(); // Task to TaskDto
            CreateMap<TaskDto, Task>().ReverseMap(); // TaskDto to Task
            CreateMap<CreateTaskInput, Task>().ReverseMap(); // TaskDto to Task
            CreateMap<UpdateTaskInput, Task>().ReverseMap(); // TaskDto to Task
        }
    }
}
