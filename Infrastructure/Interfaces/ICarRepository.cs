using microservice.Model;

namespace microservice.Infrastructure.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllAsync();
        Task<Car> InsertAsync(Car car);
    }
}
