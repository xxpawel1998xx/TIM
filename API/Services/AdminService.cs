using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Interfaces;

namespace API.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;

        }


        public async Task<ClientDto> GetClientsByNameAsyncService(string username)
        {
            
            var user = await _adminRepository.GetClientsByNameAsyncRepo(username);
            if(user.Username != username) throw new Exception();

            return user;
        }

         public async Task<IEnumerable<ClientDto>> GetClientsAsyncService()
        {
           return await _adminRepository.GetClientsAsyncRepo();
        }
    }
}