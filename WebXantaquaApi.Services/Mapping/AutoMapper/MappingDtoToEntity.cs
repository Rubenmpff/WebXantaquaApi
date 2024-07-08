using AutoMapper;
using WebXantaquaApi.Services.Mapping.Dtos;

namespace WebXantaquaApi.Services.Mapping.AutoMapper
{
    public class MappingDtoToEntity : Profile
    {
        public MappingDtoToEntity()
        {
            CreateMap<ClientDto, Client>();
            CreateMap<BudgetDto, Budget>();
            CreateMap<ProjectDto, Project>();
            CreateMap<CommentDto, Comment>();
            CreateMap<PhotoDto, Photo>();
        }
    }
}
