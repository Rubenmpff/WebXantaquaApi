using WebXantaquaApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebXantaquaApi.Infra.Data.Repositories.Interfaces;

namespace WebXantaquaApi.Infra.Data.Repositories.Implementations
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly WebXantaquaApiDBContext _context;
        private readonly DbSet<Project> _dbSet;

        public ProjectRepository(WebXantaquaApiDBContext context)
        {
            _context = context;
            _dbSet = context.Set<Project>();
        }

        public async Task<List<Project>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<Project> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(Project project)
        {
            if (project == null) throw new System.ArgumentNullException(nameof(project));
            await _dbSet.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Project project)
        {
            if (project == null) throw new System.ArgumentNullException(nameof(project));
            _dbSet.Update(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Project project)
        {
            if (project == null) throw new System.ArgumentNullException(nameof(project));
            _dbSet.Remove(project);
            await _context.SaveChangesAsync();
        }
    }
}
