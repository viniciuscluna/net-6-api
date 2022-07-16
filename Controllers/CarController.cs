using AutoMapper;
using microservice.Dto;
using microservice.Infrastructure.Interfaces;
using microservice.Model;
using Microsoft.AspNetCore.Mvc;

namespace microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _repository;
        private readonly IMapper _mapper;

        public CarController(ICarRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _repository.GetAllAsync());
        }


        [HttpPost]
        public async Task<IActionResult> InsertAssync(CarDto tesla)
        {
            return Ok(await _repository.InsertAsync(_mapper.Map<Car>(tesla)));
        }
    }
}
