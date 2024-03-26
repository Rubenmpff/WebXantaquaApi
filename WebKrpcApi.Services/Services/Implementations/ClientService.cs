using Krpc.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebKrpcApi.Infra.Data.Repositories.Interfaces;
using WebKrpcApi.Services.Mapping.Dtos;

namespace WebKrpcApi.Services.Services.Implementations
{
    public class ClientService
    {
        private readonly IClientRepository _repository;
        private readonly WebKrpcApiDBContext _context;

        public ClientService(IClientRepository repository, WebKrpcApiDBContext context)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<List<ClientDto>> GetAll()
        {

            return await _repository.GetAll();
        }

        public async Task<ClientDto> GetById(int id)
        {

            return await _repository.GetById(id);
        }

        public async Task<ClientDto> Save(ClientDto client)
        {

            if(client.Id > 0)
            {
                _repository.Update(client);
            }
            else
            {
                _repository.Add(client);
            }

            await _context.SaveChangesAsync();
            return client;
        }

        public async Task Delete(ClientDto client)
        {
            _repository.Delete(client);
            await _context.SaveChangesAsync();
        }
    }
}
