using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_project.Services.TaskServices
{
    public class TaskServices : ITaskServices
    {
        private static List<MyTask> tasks = new List<MyTask> {
            new MyTask(),
            new MyTask {Id=1, Title= "New Task"}
        };

        private readonly IMapper _mapper;

        private readonly DataContext _context;
        public TaskServices(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetTaskDto>>> GetAllTasks()
        {
            var serviceResponse = new ServiceResponse<List<GetTaskDto>>();
            var dbTasks = await _context.DbTasks.ToListAsync();
            serviceResponse.Data = dbTasks.Select(p => _mapper.Map<GetTaskDto>(p)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTaskDto>> GetTaskById(int id)
        {
            var serviceResponse = new ServiceResponse<GetTaskDto>();
            try
            {
                var dbTask = await _context.DbTasks.FirstOrDefaultAsync(p => p.Id == id);
                if (dbTask is null)
                    throw new Exception($"Task with Id '{id}' not found.");
                serviceResponse.Data = _mapper.Map<GetTaskDto>(dbTask);
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTaskDto>>> AddTask(AddTaskDto newTask)
        {
            var dbTasks = await _context.DbTasks.ToListAsync();

            var serviceResponse = new ServiceResponse<List<GetTaskDto>>();
            var task = _mapper.Map<MyTask>(newTask);
            _context.DbTasks.Add(task);
            await _context.SaveChangesAsync();
            var dbTasksUpdated = await _context.DbTasks.ToListAsync();
            serviceResponse.Data = dbTasksUpdated.Select(p => _mapper.Map<GetTaskDto>(p)).ToList();
            return serviceResponse;
        }


        public async Task<ServiceResponse<GetTaskDto>> UpdateTask(UpdateTaskDto updatedTask)
        {
            var serviceResponse = new ServiceResponse<GetTaskDto>();
            try
            {
                var task = await _context.DbTasks.FirstOrDefaultAsync(p => p.Id == updatedTask.Id);
                if (task is null)
                    throw new Exception($"Task with Id '{updatedTask.Id}' not found.");

                task.Name = updatedTask.Name;
                task.Title = updatedTask.Title;
                task.Description = updatedTask.Description;
                task.Progress = updatedTask.Progress;
                task.FinishDate = updatedTask.FinishDate;
                task.StartDate = updatedTask.StartDate;
                task.ParentProjectId = updatedTask.ParentProjectId;
                task.Status = updatedTask.Status;

                await _context.SaveChangesAsync();
                var dbTasksUpdated = await _context.DbTasks.ToListAsync();
                serviceResponse.Data = _mapper.Map<GetTaskDto>(task);
            }
            catch (Exception e)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTaskDto>>> DeleteTask(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetTaskDto>>();
            try
            {
                var task = await _context.DbTasks.FirstOrDefaultAsync(p => p.Id == id);
                if (task is null)
                    throw new Exception($"task with Id '{id}' not found.");

                _context.DbTasks.Remove(task);
                await _context.SaveChangesAsync();
                var dbTasksUpdated = await _context.DbTasks.ToListAsync();
                serviceResponse.Data = dbTasksUpdated.Select(p => _mapper.Map<GetTaskDto>(p)).ToList();
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