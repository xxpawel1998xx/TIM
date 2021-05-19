using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CarController : BaseApiController
    {
      
        private readonly ICarService _carService;

        public CarController( ICarService carService)
        {
            _carService = carService;
           

        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("add")]
        public async Task<ActionResult> AddCar([FromForm] CarPhotoDto carPhotoDto)
        {

           try
           {
             var addcar = await _carService.AddCarService(carPhotoDto);
               return Ok();
           }
           catch (Exception)
           {
               
               return BadRequest("Failed to add car :/");
           }

        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<CarDto>> GetCarById(int id)
        {

           try
           {
             var getcar = await _carService.GetCarByIdAsyncService(id);
               return Ok(getcar);
           }
           catch (Exception)
           {
               
               return BadRequest();
           }

        }

        
        [HttpGet]
         public async Task<ActionResult<IEnumerable<CarDto>>> GetCars()
        {
            try
           {
             var getcars = await _carService.GetCarsAsyncService();
               return Ok(getcars);
           }
           catch (Exception)
           {
               
               return BadRequest();
           }
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpDelete("delete/{id}")]
      public async Task<ActionResult<CarDto>> DeleteCar(int id)
    {
        try
        {
            var delcar = await _carService.DeleteCarService(id);
            return Ok();
        }
        catch (Exception)
        {
            
            return BadRequest();
        }
    }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateUser([FromBody] CarUpdateDto carUpdateDto, int id)
        {
            try
            {
                var updatecars = await _carService.UpdateCarService(carUpdateDto, id);
                return Ok();
            }
            catch (Exception)
            {
                
                return BadRequest();
            }
        }

    }
}