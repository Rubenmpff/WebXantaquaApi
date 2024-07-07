using AutoMapper;
using WebKrpcApi.Services.Mapping.Dtos;

namespace WebKrpcApi.Services.Mapping.AutoMapper
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
