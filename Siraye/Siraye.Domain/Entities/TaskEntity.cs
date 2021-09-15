using Siraye.Domain.Seed;
using System;

namespace Siraye.Domain.Entities
{
    public class TaskEntity : AuditableBaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
        public Guid AssignedTo { get; set; }
    }
}
