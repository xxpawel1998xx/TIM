using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces
{
    public interface ICarRepository
    {

        Task<CarDto> GetCarByIdAsyncRepo(int id);
        Task<IEnumerable<CarDto>> GetCarsAsyncRepo();
        Task<Cars> GetCarById(int id);
      
        Task<bool> SaveAllAsync();
        void Update(Cars cars);
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
    }
}