using Demo.Data;
using Demo.Models;
using Demo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories
{
    public class DogRepository : IDogRepository
    {
        private readonly DogContext _context;

        public DogRepository(DogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dog>> GetDogsAsync()
        {
            return await _context.Dogs.ToListAsync();
        }

        public async Task<Dog?> GetDogAsync(int id)
        {
            return await _context.Dogs.FindAsync(id);
        }

        public async Task AddDogAsync(Dog dog)
        {
            _context.Dogs.Add(dog);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDogAsync(Dog dog)
        {
            _context.Entry(dog).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDogAsync(int id)
        {
            var dog = await _context.Dogs.FindAsync(id);
            if (dog != null)
            {
                _context.Dogs.Remove(dog);
                await _context.SaveChangesAsync();
            }
        }
    }
}
