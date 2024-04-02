using AutoMapper;
using Krpc.Data.Context;
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
        private readonly WebKrpcApiDBContext _context;

        public ClientService(IMapper mapper, IClientRepository repository, WebKrpcApiDBContext context)
        {
            _mapper = mapper;
            _context = context;
            _repository = repository;
        }

        public async Task<List<ClientDto>> GetAll()
        {
            List<Client> clients = await _repository.GetAll();
            return _mapper.Map<List<ClientDto>>(clients);
        }

        public async Task<ClientDto> GetById(int id)
        {

            Client client = await _repository.GetById(id);
            return _mapper.Map<ClientDto>(client);

        }

        public async Task<ClientDto> Save(ClientDto clientDto)
        {
            Client client = _mapper.Map<Client>(clientDto);

            if(clientDto.Id > 0)
            {
                _repository.Update(client);
            }
            else
            {
                _repository.Add(client);
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<ClientDto>(client);
        }

        public async Task Delete(ClientDto clientDto)
        {
            Client client = _mapper.Map<Client>(clientDto);

            _repository.Delete(client);

            await _context.SaveChangesAsync();
        }
    }
}
