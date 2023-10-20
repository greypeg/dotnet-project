using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_project.Dtos.Project;

namespace dotnet_project
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Project, GetProjectDto>();
            CreateMap<AddProjectDto, Project>();
            CreateMap<UpdateProjectDto, Project>();
            CreateMap<MyTask, GetTaskDto>();
            CreateMap<AddTaskDto, MyTask>();
            CreateMap<UpdateTaskDto, MyTask>();
        }
    }
}