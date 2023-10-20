using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_project.Models
{
    public class MyTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [Range(1, 100, ErrorMessage = "Progress must be between 0 and 100")]
        public int Progress { get; set; } = 0;
        public StatusClass Status { get; set; } = StatusClass.TODO;
        public string FinishDate { get; set; }
        public string StartDate { get; set; }
        public int ParentProjectId { get; set; }
    }
}