global using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_project.Dtos.Project;

namespace dotnet_project.Services.ProjectServices
{
    public class ProjectService : IProjectService
    {
        private static List<Project> projects = new List<Project> {
            new Project(),
            new Project {Id=1, Title= "New Project"}
        };

        private readonly IMapper _mapper;

        private readonly DataContext _context;
        public ProjectService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetProjectDto>>> GetAll()
        {
            var serviceResponse = new ServiceResponse<List<GetProjectDto>>();
            var dbProjects = await _context.Projects.ToListAsync();
            serviceResponse.Data = dbProjects.Select(p => _mapper.Map<GetProjectDto>(p)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProjectDto>> GetProjectById(int id)
        {
            var serviceResponse = new ServiceResponse<GetProjectDto>();
            try
            {
                var dbProject = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
                if (dbProject is null)
                    throw new Exception($"Project with Id '{id}' not found.");
                serviceResponse.Data = _mapper.Map<GetProjectDto>(dbProject);
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProjectDto>>> AddProject(AddProjectDto newProject)
        {
            var serviceResponse = new ServiceResponse<List<GetProjectDto>>();
            var project = _mapper.Map<Project>(newProject);
            project.Id = projects.Max(c => c.Id) + 1;
            projects.Add(project);
            serviceResponse.Data = projects.Select(p => _mapper.Map<GetProjectDto>(p)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProjectDto>> UpdateProject(UpdateProjectDto updatedProject)
        {
            var serviceResponse = new ServiceResponse<GetProjectDto>();
            try
            {
                var project = projects.FirstOrDefault(p => p.Id == updatedProject.Id);
                if (project is null)
                    throw new Exception($"Project with Id '{updatedProject.Id}' not found.");


                //update project with mapper
                /* _mapper.Map(updatedProject, project); */

                project.Name = updatedProject.Name;
                project.Title = updatedProject.Title;
                project.Description = updatedProject.Description;
                project.Progress = updatedProject.Progress;
                project.FinishDate = updatedProject.FinishDate;
                project.StartDate = updatedProject.StartDate;

                serviceResponse.Data = _mapper.Map<GetProjectDto>(project);
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProjectDto>>> DeleteProject(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetProjectDto>>();
            try
            {
                var project = projects.FirstOrDefault(p => p.Id == id);
                if (project is null)
                    throw new Exception($"Project with Id '{id}' not found.");

                projects.Remove(project);

                serviceResponse.Data = projects.Select(p => _mapper.Map<GetProjectDto>(p)).ToList();
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }
    }
}