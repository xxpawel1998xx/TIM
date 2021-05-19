using System.Threading.Tasks;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces
{
    public interface IAccountService
    {
         Task<UserDto> LoginService(LoginDto loginDto);
    }
}