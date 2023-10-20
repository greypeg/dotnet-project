using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_project.Dtos.Project
{
    public class GetProjectByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Progress { get; set; } = 0;
        public string FinishDate { get; set; }
        public string StartDate { get; set; }

        public List<MyTask> Tasks { get; set; }
    }
}