using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_project.Services.TaskServices
{
    public interface ITaskServices
    {
        Task<ServiceResponse<List<GetTaskDto>>> GetAllTasks();

        Task<ServiceResponse<GetTaskDto>> GetTaskById(int id);

        Task<ServiceResponse<List<GetTaskDto>>> AddTask(AddTaskDto task);

        Task<ServiceResponse<GetTaskDto>> UpdateTask(UpdateTaskDto task);

        Task<ServiceResponse<List<GetTaskDto>>> DeleteTask(int id);

    }
}