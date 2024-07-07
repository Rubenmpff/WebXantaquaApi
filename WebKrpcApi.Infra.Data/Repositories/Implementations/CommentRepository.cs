using Krpc.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebKrpcApi.Infra.Data.Repositories.Interfaces;

namespace WebKrpcApi.Infra.Data.Repositories.Implementations
{
    public class CommentRepository : ICommentRepository
    {
        private readonly WebKrpcApiDBContext _context;
        private readonly DbSet<Comment> _dbSet;

        public CommentRepository(WebKrpcApiDBContext context)
        {
            _context = context;
            _dbSet = context.Set<Comment>();
        }

        public async Task<List<Comment>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<Comment> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(Comment comment)
        {
            if (comment == null) throw new System.ArgumentNullException(nameof(comment));
            await _dbSet.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Comment comment)
        {
            if (comment == null) throw new System.ArgumentNullException(nameof(comment));
            _dbSet.Update(comment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Comment comment)
        {
            if (comment == null) throw new System.ArgumentNullException(nameof(comment));
            _dbSet.Remove(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> GetCommentsByApprovalStatusAsync(bool isApproved)
        {
            return await _dbSet.AsNoTracking().Where(c => c.IsApproved == isApproved).ToListAsync();
        }
    }
}
