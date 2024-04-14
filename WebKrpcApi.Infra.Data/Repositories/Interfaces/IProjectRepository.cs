using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebKrpcApi.Infra.Data.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAll();

        Task<Project> GetById(int id);

        Project Add(Project project);

        Project Update(Project project);

        void Delete(Project project);
    }
}
