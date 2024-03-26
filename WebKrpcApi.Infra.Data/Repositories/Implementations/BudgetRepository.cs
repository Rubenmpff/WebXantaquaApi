using Krpc.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebKrpcApi.Infra.Data.Repositories.Interfaces;

namespace WebKrpcApi.Infra.Data.Repositories.Implementations
{
    public class BudgetRepository : IBudgetRepository
    {
        protected WebKrpcApiDBContext _webKrpcApiDBContext;
        protected DbSet<Budget> _dbSet;

        public BudgetRepository(WebKrpcApiDBContext webKrpcApiDBContext)
        {
            _webKrpcApiDBContext = webKrpcApiDBContext;
            _dbSet = _webKrpcApiDBContext.Set<Budget>();
        }

        public async Task<List<Budget>> GetAll()
        {

            return await _dbSet.ToListAsync();
        }

        public async Task<Budget> GetById(int id)
        {

            return await _dbSet.FindAsync(id);
        }

        public Budget Add(Budget budget)
        {
            _dbSet.Add(budget);
            return budget;
        }

        public Budget Update(Budget budget)
        {
            _dbSet.Update(budget);
            return budget;
        }

        public void Delete(Budget budget)
        {
            _dbSet.Remove(budget);
        }

    }

}
