using microservice.Dto;
using microservice.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HarryController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public HarryController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public async Task<ActionResult<CharacterDto[]>> GetAsync()
        {
            return Ok(await _characterService.GetAllAsync());
        }
    }
}
