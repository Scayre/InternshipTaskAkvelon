using System;
using System.Collections.Generic;

#nullable disable

namespace InternshipTaskAkvelon.Models
{
    public partial class Project
    {
        public Project()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public string Status { get; set; }
        public int Priority { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
