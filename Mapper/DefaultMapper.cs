using AutoMapper;
using microservice.Dto;
using microservice.Model;

namespace microservice.Mapper
{
    public class DefaultMapper : Profile
    {
        public DefaultMapper()
        {
            CreateMap<Car, CarDto>().ReverseMap();
        }
    }
}
