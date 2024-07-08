using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebXantaquaApi.Services.Mapping.Dtos;

namespace WebXantaquaApi.Services.Services.Interfaces
{
    public interface IProjectService
    {
        Task<List<ProjectDto>> GetAll();

        Task<ProjectDto> GetById(int id);

        Task<ProjectDto> Save(ProjectDto projectDto);

        Task Delete(ProjectDto projectDto);
    }
}
