using System;

namespace InternshipTaskAkvelon.Responses
{
    public class ProjectResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime CompletionDate { get; set; }
        
        public string Status { get; set; }
    }
}