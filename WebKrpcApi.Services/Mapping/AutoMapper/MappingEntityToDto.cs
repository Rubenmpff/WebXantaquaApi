using AutoMapper;
using WebKrpcApi.Services.Mapping.Dtos;

namespace WebKrpcApi.Services.Mapping.AutoMapper
{
    public class MappingEntityToDto : Profile
    {
        public MappingEntityToDto()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<Budget, BudgetDto>();
            CreateMap<Project, ProjectDto>();
            CreateMap<Comment, CommentDto>();
            CreateMap<Photo, PhotoDto>();
        }
    }
}