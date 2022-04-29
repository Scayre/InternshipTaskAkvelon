using System.Collections.Generic;
using System.Linq;
using InternshipTaskAkvelon.DTO;
using InternshipTaskAkvelon.Interfaces;
using InternshipTaskAkvelon.Models;
using InternshipTaskAkvelon.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InternshipTaskAkvelon.Controllers
{
    [ApiController, Route("[controller]")]
    public class ProjectController : Controller
    {
        private ILogger<ProjectController> _logger;
        private AkvelonTaskContext _akvelonTaskContext;
        private IResponseFactory _responseFactory;

        public ProjectController(ILogger<ProjectController> logger, AkvelonTaskContext akvelonTaskContext,
            IResponseFactory responseFactory)
        {
            _logger = logger;
            _akvelonTaskContext = akvelonTaskContext;
            _responseFactory = responseFactory;
        }

        #region Get Requests

        /// <summary>
        /// Method will return all projects
        /// </summary>
        [HttpGet, Route("view/projects")]
        public ActionResult<List<ProjectResponse>> ViewProjects()
        {
            return Json(_akvelonTaskContext.Projects.Select(project => _responseFactory.BuildProject(project))
                .ToList());
        }

        /// <summary>
        /// Method will return task details
        /// </summary>
        /// <param name="id">Task id</param>
        [HttpGet, Route("view/task/{id:int}")]
        public ActionResult<TaskResponse> ViewTask(int id)
        {
            return Json(_akvelonTaskContext.Tasks.Where(task => task.Id == id)
                .Select(task => _responseFactory.BuildTask(task)).FirstOrDefault());
        }

        /// <summary>
        /// Method will return all tasks of project
        /// </summary>
        /// <param name="id">Project id</param>
        [HttpGet, Route("view/project/tasks/{id:int}")]
        public ActionResult<List<TaskResponse>> ViewTasksFromProject(int id)
        {
            var response = new List<TaskResponse>();
            var list = _akvelonTaskContext.Projects.Where(project => project.Id == id).Include(project => project.Tasks)
                .FirstOrDefault()
                ?.Tasks.ToList();
            if (list != null) response.AddRange(list.Select(t => _responseFactory.BuildTask(t)));

            return Json(response);
        }

        #endregion

        #region Put Requests

        /// <summary>
        /// Method will edit project details
        /// </summary>
        /// <param name="id">Project id</param>
        /// <param name="dto">Updated data of project</param>
        [HttpPut, Route("edit/project/{id:int}")]
        public ActionResult EditProject(int id, [FromBody] ProjectDTO dto)
        {
            var project = _akvelonTaskContext.Projects.FirstOrDefault(project => project.Id == id);
            if (project == null)
            {
                return NotFound(new {errorText = "Project not found!"});
            }

            project.Name = dto.Name ?? project.Name;
            project.Description = dto.Description ?? project.Description;
            project.CreationDate = dto.StartDate;
            project.CompletionDate = dto.CompletionDate;
            project.Status = dto.Status ?? project.Status;
            project.Priority = dto.Priority;
            _akvelonTaskContext.Update(project);
            _akvelonTaskContext.SaveChanges();
            return Ok();
        }
        
        /// <summary>
        /// Method will edit task details
        /// </summary>
        /// <param name="id">Task id</param>
        /// <param name="dto">Updated data of task</param>
        [HttpPut, Route("edit/task/{id:int}")]
        public ActionResult EditTask(int id, [FromBody] TaskDTO dto)
        {
            var task = _akvelonTaskContext.Tasks.FirstOrDefault(task => task.Id == id);
            if (task == null)
            {
                return NotFound(new {errorText = "Task not found!"});
            }

            task.Name = dto.Name ?? task.Name;
            task.Description = dto.Description ?? task.Description;
            task.Status = dto.Status ?? task.Status;
            task.Priority = dto.Priority;
            task.ProjectId = dto.ProjectId;
            _akvelonTaskContext.Update(task);
            _akvelonTaskContext.SaveChanges();
            return Ok();
        }

        #endregion
        
    }
}