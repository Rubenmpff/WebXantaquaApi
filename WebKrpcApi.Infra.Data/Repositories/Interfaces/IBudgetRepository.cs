using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebKrpcApi.Infra.Data.Repositories.Interfaces
{
    public interface IBudgetRepository
    {
        Task<List<Budget>> GetAll();
        Task<Budget> GetById(int id);
        Task AddAsync(Budget budget);
        Task UpdateAsync(Budget budget);
        Task DeleteAsync(Budget budget);
    }
}
