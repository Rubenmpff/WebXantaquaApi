using Krpc.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebKrpcApi.Infra.Data.Repositories.Interfaces;

namespace WebKrpcApi.Infra.Data.Repositories.Implementations
{
    public class ClientRepository : IClientRepository
    {
        private readonly WebXantaquaApiDBContext _context;
        private readonly DbSet<Client> _dbSet;

        public ClientRepository(WebXantaquaApiDBContext context)
        {
            _context = context;
            _dbSet = context.Set<Client>();
        }

        public async Task<List<Client>> GetAll()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<Client> GetByEmail(string email)
        {
            return await _dbSet.AsNoTracking().SingleOrDefaultAsync(c => c.Email == email);
        }

        public async Task AddAsync(Client client)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            await _dbSet.AddAsync(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Client client)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            _dbSet.Update(client);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Client client)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            _dbSet.Remove(client);
            await _context.SaveChangesAsync();
        }
    }
}
