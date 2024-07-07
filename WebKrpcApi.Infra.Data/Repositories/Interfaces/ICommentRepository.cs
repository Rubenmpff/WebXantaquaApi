using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebKrpcApi.Infra.Data.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAll();
        Task<Comment> GetById(int id);
        Task AddAsync(Comment comment);
        Task UpdateAsync(Comment comment);
        Task DeleteAsync(Comment comment);
        Task<IEnumerable<Comment>> GetCommentsByApprovalStatusAsync(bool isApproved);
    }
}