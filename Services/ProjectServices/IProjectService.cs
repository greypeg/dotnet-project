using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_project.Dtos.Project;

namespace dotnet_project.Services.ProjectServices
{
    public interface IProjectService
    {
        Task<ServiceResponse<List<GetProjectDto>>> GetAll();

        Task<ServiceResponse<GetProjectDto>> GetProjectById(int id);

        Task<ServiceResponse<List<GetProjectDto>>> AddProject(AddProjectDto project);

        Task<ServiceResponse<GetProjectDto>> UpdateProject(UpdateProjectDto project);

        Task<ServiceResponse<List<GetProjectDto>>> DeleteProject(int id);
    }
}