using InternshipTaskAkvelon.Interfaces;
using InternshipTaskAkvelon.Models;
using InternshipTaskAkvelon.Responses;

namespace InternshipTaskAkvelon.Services
{
    public class ResponseFactory:IResponseFactory
    {
        public ProjectResponse BuildProject(Project project)
        {
            return new ProjectResponse
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                StartDate = project.CreationDate,
                CompletionDate = project.CompletionDate,
                Status = project.Status
            };
        }

        public TaskResponse BuildTask(Task task)
        {
            return new TaskResponse
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Status = task.Status
            };
        }
    }
}