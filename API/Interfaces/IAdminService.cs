using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;

namespace API.Interfaces
{
    public interface IAdminService
    {
         Task<ClientDto> GetClientsByNameAsyncService(string username);
         Task<IEnumerable<ClientDto>> GetClientsAsyncService();
    }
}