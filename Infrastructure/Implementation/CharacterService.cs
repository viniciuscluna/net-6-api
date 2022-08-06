using microservice.Dto;
using microservice.Infrastructure.Interfaces;

namespace microservice.Infrastructure.Implementation
{
    public class CharacterService : ICharacterService
    {
        private readonly ILogger _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        public CharacterService(ILogger<CharacterService> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<CharacterDto[]> GetAllAsync()
        {
            _logger.LogInformation($"Test call Harry");
            var client = _httpClientFactory.CreateClient("Harry");
            var result = await client.GetAsync("/api/characters");
            if (result.IsSuccessStatusCode)
                return await result.Content.ReadFromJsonAsync<CharacterDto[]>() ?? Array.Empty<CharacterDto>();
            else throw new Exception();
        }
    }
}
