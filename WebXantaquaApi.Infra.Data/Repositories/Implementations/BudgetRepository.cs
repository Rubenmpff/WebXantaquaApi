using WebXantaquaApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebXantaquaApi.Infra.Data.Repositories.Interfaces;

namespace WebXantaquaApi.Infra.Data.Repositories.Implementations
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly WebXantaquaApiDBContext _context;
        private readonly DbSet<Budget> _dbSet;

        public BudgetRepository(WebXantaquaApiDBContext context)
        {
            _context = context;
            _dbSet = context.Set<Budget>();
        }

        public async Task<List<Budget>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<Budget> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(Budget budget)
        {
            if (budget == null) throw new ArgumentNullException(nameof(budget));
            await _dbSet.AddAsync(budget);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Budget budget)
        {
            if (budget == null) throw new ArgumentNullException(nameof(budget));
            _dbSet.Update(budget);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Budget budget)
        {
            if (budget == null) throw new ArgumentNullException(nameof(budget));
            _dbSet.Remove(budget);
            await _context.SaveChangesAsync();
        }
    }
}
