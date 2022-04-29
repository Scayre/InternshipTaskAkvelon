using System;

namespace InternshipTaskAkvelon.DTO
{
    public class ProjectDTO
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime CompletionDate { get; set; }
        
        public string Status { get; set; }
        
        public int Priority { get; set; }
    }
}