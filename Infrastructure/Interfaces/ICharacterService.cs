using microservice.Dto;

namespace microservice.Infrastructure.Interfaces
{
    public interface ICharacterService
    {
        Task<CharacterDto[]> GetAllAsync();
    }
}
