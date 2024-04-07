using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebKrpcApi.Services.Mapping.Dtos;
using WebKrpcApi.Services.Services.Interfaces;

namespace WebKrpcApi.Controllers
{
    [Route("WebKrpcApi/[controller]")]
    // WebKrpcApi/budget
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _service;

        public ProjectController(IProjectService projectService)
        {
            _service = projectService;
        }

        [HttpGet]
        public List<ProjectDto> GetAll()
        {
            return _service.GetAll().Result;
        }

        [HttpGet("{id}")]
        public ProjectDto GetClient(int id)
        {
            return _service.GetById(id).Result;
        }

        [HttpPost]
        public ProjectDto Save(ProjectDto projectDto)
        {
            return _service.Save(projectDto).Result;
        }

        [HttpDelete]
        public void Delete(ProjectDto projectDto)
        {
            _service.Delete(projectDto);
        }
    }
}