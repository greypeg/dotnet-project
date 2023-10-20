using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_project.Dtos.Task
{
    public class AddTaskDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Progress { get; set; } = 0;
        public string Status { get; set; }
        public string FinishDate { get; set; }
        public string StartDate { get; set; }
        public int ParentProjectId { get; set; }
    }
}