using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IClientRepository
    {
         Task<Cars> GetCarById(int id);

         Task<ClientDto> GetClientsByNameAsync(string username);

         Task<ClientDto> GetClientsByIdAsync(int id);

         Task<bool> SaveAllAsync();
         void Update(Cars cars);
    }
}