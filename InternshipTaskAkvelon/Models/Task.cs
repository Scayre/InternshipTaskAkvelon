using System;
using System.Collections.Generic;

#nullable disable

namespace InternshipTaskAkvelon.Models
{
    public partial class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
