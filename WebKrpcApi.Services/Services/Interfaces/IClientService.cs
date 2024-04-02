using System.Collections.Generic;
using System.Threading.Tasks;
using WebKrpcApi.Services.Mapping.Dtos;

namespace WebKrpcApi.Services.Services.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientDto>> GetAll();

        Task<ClientDto> GetById(int id);

        Task<ClientDto> Save(ClientDto clientDto);

        Task Delete(ClientDto clientDto);

    }
}
