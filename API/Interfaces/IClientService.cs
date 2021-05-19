using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces
{
    public interface IClientService
    {
       Task<IAsyncResult> AddCarToClient(int userid, int id);
       Task<IAsyncResult> RemoveCarFromClient(int userid, int id);
    }
}