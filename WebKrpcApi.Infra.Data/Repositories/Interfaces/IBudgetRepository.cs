
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebKrpcApi.Infra.Data.Repositories.Interfaces
{
    public interface IBudgetRepository
    {
        Task<List<Budget>> GetAll();

        Task<Budget> GetById(int id);

        Budget Add(Budget budget);

        Budget Update(Budget budget);

        void Delete(Budget budget);
    }
}
