using Krpc.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebKrpcApi.Infra.Data.Repositories.Interfaces;

namespace WebKrpcApi.Infra.Data.Repositories.Implementations
{
    public class ClientRepository : IClientRepository
    {
        protected WebKrpcApiDBContext _webKrpcApiDBContext;
        protected DbSet<Client> _dbSet;

        public ClientRepository(WebKrpcApiDBContext webKrpcApiDBContext)
        {
            _webKrpcApiDBContext = webKrpcApiDBContext;
            _dbSet = _webKrpcApiDBContext.Set<Client>();
        }

        public async Task<List<Client>> GetAll()
        {

            return await _dbSet.ToListAsync();
        }

        public async Task<Client> GetById(int id)
        {

            return await _dbSet.FindAsync(id);
        }

        public Client Add(Client client)
        {
            _dbSet.Add(client);
            return client;
        }

        public Client Update(Client client)
        {
            _dbSet.Update(client);
            return client;
        }

        public void Delete(Client client)
        {
            _dbSet.Remove(client);
        }

    }
}
