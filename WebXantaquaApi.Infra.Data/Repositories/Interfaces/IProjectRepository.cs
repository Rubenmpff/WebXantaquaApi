using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebXantaquaApi.Infra.Data.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAll();
        Task<Project> GetById(int id);
        Task AddAsync(Project project);
        Task UpdateAsync(Project project);
        Task DeleteAsync(Project project);
    }
}
