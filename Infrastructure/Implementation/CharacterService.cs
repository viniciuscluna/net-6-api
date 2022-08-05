using microservice.Dto;
using microservice.Infrastructure.Interfaces;

namespace microservice.Infrastructure.Implementation
{
    public class CharacterService : ICharacterService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CharacterService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<CharacterDto[]> GetAllAsync()
        {
            var client = _httpClientFactory.CreateClient("Harry");
            var result = await client.GetAsync("/api/characters");
            if (result.IsSuccessStatusCode)
                return await result.Content.ReadFromJsonAsync<CharacterDto[]>() ?? Array.Empty<CharacterDto>();
            else throw new Exception();
        }
    }
}
