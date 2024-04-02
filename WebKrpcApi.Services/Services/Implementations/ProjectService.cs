using AutoMapper;
using Krpc.Data.Context;
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
        private readonly IProjectRepository _repository;
        private readonly WebKrpcApiDBContext _context;

        public ProjectService(IMapper mapper, IProjectRepository repository, WebKrpcApiDBContext context)
        {
            _mapper = mapper;
            _context = context;
            _repository = repository;
        }

        public async Task<List<ProjectDto>> GetAll()
        {
            List<Project> projects = await _repository.GetAll();
            return _mapper.Map<List<ProjectDto>>(projects);
        }

        public async Task<ProjectDto> GetById(int id)
        {

            Project project = await _repository.GetById(id);
            return _mapper.Map<ProjectDto>(project);

        }

        public async Task<ProjectDto> Save(ProjectDto projectDto)
        {
            Project project = _mapper.Map<Project>(projectDto);

            if (projectDto.Id > 0)
            {
                _repository.Update(project);
            }
            else
            {
                _repository.Add(project);
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<ProjectDto>(project);
        }

        public async Task Delete(ProjectDto projectDto)
        {
            Project project = _mapper.Map<Project>(projectDto);

            _repository.Delete(project);

            await _context.SaveChangesAsync();
        }
    }

}
