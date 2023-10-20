using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        //inject task service
        private readonly ITaskServices _taskService;
        public TaskController(ITaskServices taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetTaskDto>>>> Get()
        {
            return Ok(await _taskService.GetAllTasks());
        }

        //declare parameter id
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTaskDto>>> GetSingle(int id)
        {
            var response = await _taskService.GetTaskById(id);

            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<AddTaskDto>>>> AddPTask(AddTaskDto task)
        {
            return Ok(await _taskService.AddTask(task));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetTaskDto>>> UpdateTask(UpdateTaskDto updatedTask)
        {
            var response = await _taskService.UpdateTask(updatedTask);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTaskDto>>> DeleteTask(int id)
        {
            var response = await _taskService.DeleteTask(id);
            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}