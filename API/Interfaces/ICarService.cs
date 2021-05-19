using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Interfaces
{
    public interface ICarService
    {
       Task<CarDto> AddCarService([FromForm] CarPhotoDto carPhotoDto);

       Task<CarDto> GetCarByIdAsyncService(int id);

       Task<IEnumerable<CarDto>> GetCarsAsyncService();

       Task<IAsyncResult> DeleteCarService(int id);

       Task<IAsyncResult> UpdateCarService([FromBody] CarUpdateDto carUpdateDto, int id);
     
    }
}