using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_project.Services.TaskServices
{
    public class TaskServices : ITaskServices
    {
         private static List<Project> projects = new List<Project> {
            new Project(),
            new Project {Id=1, Title= "New Project"}
        };

        private readonly IMapper _mapper;

        private readonly DataContext _context;
        public TaskServices(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<ServiceResponse<List<GetTaskDto>>> AddTask(AddTaskDto task)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetTaskDto>>> DeleteTask(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetTaskDto>>> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetTaskDto>> GetTaskById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetTaskDto>> UpdateTask(UpdateTaskDto task)
        {
            throw new NotImplementedException();
        }
    }
}