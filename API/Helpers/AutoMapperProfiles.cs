using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, ClientDto>();
            CreateMap<CarDto, Cars>();
            CreateMap<Cars, CarDto>();
            CreateMap<CarUpdateDto, Cars>();
        }
    }
}