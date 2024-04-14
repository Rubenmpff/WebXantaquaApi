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
        private readonly IEmailService _emailService;
        private readonly IProjectRepository _repository;
        private readonly WebKrpcApiDBContext _context;


        public ProjectService(IMapper mapper, IProjectRepository repository, WebKrpcApiDBContext context, IEmailService emailService)
        {
            _mapper = mapper;
            _context = context;
            _repository = repository;
            _emailService = emailService; // Guarda a referência ao serviço de e-mail

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
                // Após adicionar o projeto, vamos enviar um e-mail
                await _context.SaveChangesAsync(); // Garante que o projeto seja guardado antes de enviar o e-mail
                await _emailService.SendEmailAsync(new EmailRequest
                {
                    To = "email@exemplo.com",
                    Subject = "Novo Projeto Criado",
                    Body = $"Um novo projeto foi criado: {projectDto.Name}"
                });
            }

            // Se você desejar retornar o DTO atualizado com o ID (se for um novo projeto)
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
