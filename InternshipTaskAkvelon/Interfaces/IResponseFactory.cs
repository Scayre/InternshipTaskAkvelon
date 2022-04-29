using InternshipTaskAkvelon.Models;
using InternshipTaskAkvelon.Responses;

namespace InternshipTaskAkvelon.Interfaces
{
    public interface IResponseFactory
    {
        ProjectResponse BuildProject(Project project);

        TaskResponse BuildTask(Task task);
    }
}