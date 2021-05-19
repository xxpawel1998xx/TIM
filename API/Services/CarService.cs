using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace API.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
         private readonly Cloudinary _cloudinary;
        public CarService(IOptions<CloudinarySettings> config, ICarRepository carRepository, IMapper mapper)
        {
           
            _mapper = mapper;
            _carRepository = carRepository;

            var acc = new Account
            (
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
        }
            public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream)
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        public async Task<CarDto> AddCarService([FromForm] CarPhotoDto carPhotoDto)
        {
            var result = await AddPhotoAsync(carPhotoDto.File);

            var car = new Cars
            { 
                CarPhotoUrl = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId,
                Car = carPhotoDto.Car,
                Brand = carPhotoDto.Brand,
                FuelType = carPhotoDto.FuelType,
                Year = carPhotoDto.Year,
                Price = carPhotoDto.Price,
                Mileage = carPhotoDto.Mileage,
                isTaken = false,
                AppUserId = 4


            };
            _carRepository.Add<Cars>(car);
            if (await _carRepository.SaveAllAsync())
                return _mapper.Map<CarDto>(car);

            throw new Exception();

        }


        public async Task<CarDto> GetCarByIdAsyncService(int id)
        {
            var getcar = await _carRepository.GetCarByIdAsyncRepo(id);

            if (getcar.Id != id)
            {
                throw new Exception();
            }

            return getcar;
        }

        public async Task<IEnumerable<CarDto>> GetCarsAsyncService()
        {
            return await _carRepository.GetCarsAsyncRepo();
        }

        public async Task<IAsyncResult> DeleteCarService(int id)
        {


            var car = await _carRepository.GetCarById(id);
            if (car == null) throw new Exception("Car doesn't exist");


            _carRepository.Delete<Cars>(car);

            if (await _carRepository.SaveAllAsync()) return Task.CompletedTask;

            throw new Exception("Failed to delete car");
        }


        public async Task<IAsyncResult> UpdateCarService([FromBody] CarUpdateDto carUpdateDto, int id)
        {


            var car = await _carRepository.GetCarById(id);
            if (car == null) throw new Exception("Car doesn't exist");

            _mapper.Map(carUpdateDto, car);
            _carRepository.Update(car);

            if (await _carRepository.SaveAllAsync()) return Task.CompletedTask;

            throw new Exception("Failed to delete car");
        }


    }
}