using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RQM.Data.Model;
using RQM.Data.Request;

namespace RQM.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Project")]
    public class ProjectController : Controller
    {
        // logging
        private readonly ILogger _logger;
        public ProjectController(ILogger<ProjectController> logger)
        {
            _logger = logger;
        }

        // Global ReadProject class
        ReadProject readProject = new ReadProject();

        // Global WriteProject clss
        WriteProject writeProject = new WriteProject();

        // GET: api/Project
        [HttpGet]
        public string Get()
        {

            string projectList = "";
            try
            {
                _logger.LogInformation("Getting project list");
                projectList = readProject.getProjects();
                return projectList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        // GET: api/Project/Admin
        // name convention: pascal
        [HttpGet("{groupTypeName}", Name = "Get")]
        public string Get(string groupTypeName)
        {
            string projectList = "";
            try
            {
                _logger.LogInformation("Getting project list by group type name: {groupTypeName}", groupTypeName);
                projectList = readProject.getProjectsByAccessGroupTypeName(groupTypeName);
                return projectList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        // POST: api/Project
        // Need Authentication?
        [HttpPost]
        public void Post([FromBody] ProjectSelection projectSelection)
        {

            try
            {
                _logger.LogInformation("Creating new project selection: {p.PojectListID}", projectSelection.ProjectListID);
                // CreatedBy and UpdatedBy are the same for creating Project_Selection
                writeProject.InsertProjectSelection(projectSelection.ProjectListID, projectSelection.CreatedBy, projectSelection.UpdatedBy, DateTime.Now);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }

        }
        
        // PUT: api/Project/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
