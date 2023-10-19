using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private static List<Project> projects = new List<Project> {
            new Project()
        };

        [HttpGet("GetAll")]
        public ActionResult<List<Project>> Get()
        {
            return Ok(projects);
        }

        //declare parameter id
        [HttpGet("{id}")]
        public ActionResult<Project> GetSingle(int id)
        {
            return Ok(projects.FirstOrDefault(p => p.Id == id));
        }

        [HttpPost]
        public ActionResult<List<Project>> AddProject(Project project)
        {
            projects.Add(project);
            return Ok(projects);
        }
    }
}