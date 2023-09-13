using ApplicationShared.Dto.NotificationDto;
using ApplicationShared.Dto.ProjectDto;
using AutoMapper;
using TaskManagementSystem.Core.Entities;

namespace TaskManagementSystem.Web.CustomDtoMapper
{
    public class ProjectProfile: Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<CreateProjectInput, Project>().ReverseMap();
            CreateMap<UpdateProjectInput, Project>().ReverseMap();
        }
    }
}
