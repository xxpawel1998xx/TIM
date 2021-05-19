using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CarRepository : ICarRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CarRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }


        public async Task<CarDto> GetCarByIdAsyncRepo(int id)
        {
            return await _context.Cars
            .Where(x => x.Id == id)
            .ProjectTo<CarDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }
        public async Task<Cars> GetCarById(int id)
        {
            return await _context.Cars.FirstOrDefaultAsync(u => u.Id == id);
        }


         public async Task<IEnumerable<CarDto>> GetCarsAsyncRepo()
        {
            return await _context.Cars
            .ProjectTo<CarDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

      

        public void Update(Cars cars)
        {
            _context.Entry(cars).State = EntityState.Modified; //adds flag to entity that it has been modified
        }



        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
    }
}