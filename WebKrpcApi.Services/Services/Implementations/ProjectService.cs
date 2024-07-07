using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebKrpcApi.Infra.Data.Repositories.Interfaces;
using WebKrpcApi.Services.Mapping.Dtos;
using WebKrpcApi.Services.Services.Interfaces;

namespace WebKrpcApi.Services.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IProjectRepository _repository;

        public ProjectService(IMapper mapper, IProjectRepository repository, IEmailService emailService)
        {
            _mapper = mapper;
            _repository = repository;
            _emailService = emailService;
        }

        public async Task<List<ProjectDto>> GetAll()
        {
            var projects = await _repository.GetAll();
            return _mapper.Map<List<ProjectDto>>(projects);
        }

        public async Task<ProjectDto> GetById(int id)
        {
            var project = await _repository.GetById(id);
            if (project == null)
                throw new KeyNotFoundException("Project not found.");
            return _mapper.Map<ProjectDto>(project);
        }

        public async Task<ProjectDto> Save(ProjectDto projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            if (project.Id > 0)
            {
                await _repository.UpdateAsync(project);
            }
            else
            {
                await _repository.AddAsync(project);
                // Consider using an event-based approach for sending emails, for better separation of concerns
                // _emailService.SendProjectCreatedEmail(project); // Implement this method in your email service
            }
            return _mapper.Map<ProjectDto>(project);
        }

        public async Task Delete(ProjectDto projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);
            await _repository.DeleteAsync(project);
        }
    }
}
