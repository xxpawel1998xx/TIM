using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ClientRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }

         public async Task<Cars> GetCarById(int id)
        {
            return await _context.Cars.FirstOrDefaultAsync(u => u.Id == id);
        }

         public async Task<ClientDto> GetClientsByNameAsync(string username)
        {
            return await _context.Users
            .Where(x => x.UserName == username)
            .ProjectTo<ClientDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }

         public async Task<ClientDto> GetClientsByIdAsync(int id)
        {
            return await _context.Users
            .Where(x => x.Id == id)
            .ProjectTo<ClientDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }

         public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        public void Update(Cars cars)
        {
            _context.Entry(cars).State = EntityState.Modified; //adds flag to entity that it has been modified
        }

    }
}