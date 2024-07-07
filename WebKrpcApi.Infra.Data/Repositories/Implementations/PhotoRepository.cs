using Krpc.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebKrpcApi.Infra.Data.Repositories.Interfaces;

namespace WebKrpcApi.Infra.Data.Repositories.Implementations
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly WebXantaquaApiDBContext _context;
        private readonly DbSet<Photo> _dbSet;

        public PhotoRepository(WebXantaquaApiDBContext context)
        {
            _context = context;
            _dbSet = context.Set<Photo>();
        }

        public async Task<List<Photo>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<Photo> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<Photo>> GetByProjectId(int projectId)
        {
            return await _dbSet.AsNoTracking().Where(p => p.ProjectId == projectId).ToListAsync();
        }

        public async Task AddAsync(Photo photo)
        {
            if (photo == null) throw new System.ArgumentNullException(nameof(photo));
            await _dbSet.AddAsync(photo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Photo photo)
        {
            if (photo == null) throw new System.ArgumentNullException(nameof(photo));
            _dbSet.Update(photo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Photo photo)
        {
            if (photo == null) throw new System.ArgumentNullException(nameof(photo));
            _dbSet.Remove(photo);
            await _context.SaveChangesAsync();
        }
    }
}
