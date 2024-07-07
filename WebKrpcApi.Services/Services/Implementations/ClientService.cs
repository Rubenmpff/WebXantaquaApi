using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebKrpcApi.Infra.Data.Repositories.Interfaces;
using WebKrpcApi.Services.Mapping.Dtos;
using WebKrpcApi.Services.Services.Interfaces;

namespace WebKrpcApi.Services.Services.Implementations
{
    public class ClientService : IClientService
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _repository;

        public ClientService(IMapper mapper, IClientRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<ClientDto>> GetAll()
        {
            var clients = await _repository.GetAll();
            return _mapper.Map<List<ClientDto>>(clients);
        }

        public async Task<ClientDto> GetByEmail(string email)
        {
            var client = await _repository.GetByEmail(email);
            if (client == null) throw new KeyNotFoundException("Cliente não encontrado.");
            return _mapper.Map<ClientDto>(client);
        }

        public async Task<ClientDto> Save(ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            var existingClient = await _repository.GetByEmail(client.Email);
            if (existingClient != null)
            {
                client.Id = existingClient.Id; // Certifique-se de que o ID está sendo mantido para atualização.
                await _repository.UpdateAsync(client);
            }
            else
            {
                await _repository.AddAsync(client);
            }
            return _mapper.Map<ClientDto>(client);
        }

        public async Task Delete(ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            await _repository.DeleteAsync(client);
        }
    }
}
