using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;

namespace API.Interfaces
{
    public interface IAdminRepository
    {
         Task<ClientDto> GetClientsByNameAsyncRepo(string username);
         Task<IEnumerable<ClientDto>> GetClientsAsyncRepo();
    }
}