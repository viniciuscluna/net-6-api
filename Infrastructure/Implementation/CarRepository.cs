using microservice.Context;
using microservice.Infrastructure.Interfaces;
using microservice.Model;
using Microsoft.EntityFrameworkCore;

namespace microservice.Infrastructure.Implementation
{
    public class CarRepository : ICarRepository
    {
        private readonly TeslaContext _context;
        public CarRepository(TeslaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _context.Car.ToArrayAsync();
        }

        public async Task<Car> InsertAsync(Car car)
        {
            _context.Car.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }
    }
}
