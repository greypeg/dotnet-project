using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_project.Dtos.Project;
using dotnet_project.Models;
using dotnet_project.Services.ProjectServices;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        //inject project service
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetProjectDto>>>> Get()
        {
            return Ok(await _projectService.GetAll());
        }

        //declare parameter id
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetProjectDto>>> GetSingle(int id)
        {
            var response = await _projectService.GetProjectById(id);

            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<AddProjectDto>>>> AddProject(AddProjectDto project)
        {
            return Ok(await _projectService.AddProject(project));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetProjectDto>>> UpdateProject(UpdateProjectDto updatedProject)
        {
            var response = await _projectService.UpdateProject(updatedProject);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetProjectDto>>> DeleteProject(int id)
        {
            var response = await _projectService.DeleteProject(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}