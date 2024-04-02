using Krpc.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebKrpcApi.Infra.Data.Repositories.Interfaces;

namespace WebKrpcApi.Infra.Data.Repositories.Implementations
{
    public class ProjectRepository : IProjectRepository
    {
        protected WebKrpcApiDBContext _webKrpcApiDBContext;
        protected DbSet<Project> _dbSet;

        public ProjectRepository(WebKrpcApiDBContext webKrpcApiDBContext)
        {
            _webKrpcApiDBContext = webKrpcApiDBContext;
            _dbSet = _webKrpcApiDBContext.Set<Project>();
        }

        public async Task<List<Project>> GetAll()
        {

            return await _dbSet.ToListAsync();
        }

        public async Task<Project> GetById(int id)
        {

            return await _dbSet.FindAsync(id);
        }

        public Project Add(Project project)
        {
            _dbSet.Add(project);
            return project;
        }

        public Project Update(Project project)
        {
            _dbSet.Update(project);
            return project;
        }

        public void Delete(Project project)
        {
            _dbSet.Remove(project);
        }

    }
}
