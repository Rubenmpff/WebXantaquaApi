using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebXantaquaApi.Infra.Data.Repositories.Interfaces
{
    public interface IPhotoRepository
    {
        Task<List<Photo>> GetAll();
        Task<Photo> GetById(int id);
        Task<List<Photo>> GetByProjectId(int projectId);
        Task AddAsync(Photo photo);
        Task UpdateAsync(Photo photo);
        Task DeleteAsync(Photo photo);
    }
}
