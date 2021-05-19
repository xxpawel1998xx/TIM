using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public AdminRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }
        public async Task<ClientDto> GetClientsByNameAsyncRepo(string username)
        {
            return await _context.Users
            .Where(x => x.UserName == username)
            .ProjectTo<ClientDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }


         public async Task<IEnumerable<ClientDto>> GetClientsAsyncRepo()
        {
            return await _context.Users
            .ProjectTo<ClientDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }
    }
}