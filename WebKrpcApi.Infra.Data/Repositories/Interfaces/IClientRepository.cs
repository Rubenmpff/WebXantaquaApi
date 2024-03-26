
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebKrpcApi.Infra.Data.Repositories.Interfaces
{
    public interface IClientRepository 
    {
        Task<List<Client>> GetAll();

        Task<Client> GetById(int id);

        Client Add(Client client);

        Client Update(Client client);

        void Delete(Client client);

    }
}
