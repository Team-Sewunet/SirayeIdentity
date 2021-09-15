using System;
using System.Collections.Generic;
using System.Text;

namespace Siraye.Application.Features.Tasks.Queries.GetAllTasks
{
    public class GetAllTasksViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
        public Guid AssignedTo { get; set; }
    }
}
