using Demo.Models;
using Demo.Interfaces;

namespace Demo.Services
{
    public class DogService : IDogService
    {
        private readonly IDogRepository _repository;

        public DogService(IDogRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Dog>> GetDogsAsync()
        {
            return await _repository.GetDogsAsync();
        }

        public async Task<Dog?> GetDogAsync(int id)
        {
            return await _repository.GetDogAsync(id);
        }

        public async Task AddDogAsync(Dog dog)
        {
            await _repository.AddDogAsync(dog);
        }

        public async Task<bool> UpdateDogAsync(Dog dog)
        {
            var existingDog = await _repository.GetDogAsync(dog.Id);
            if (existingDog == null)
            {
                return false;
            }

            await _repository.UpdateDogAsync(dog);
            return true;
        }

        public async Task<bool> DeleteDogAsync(int id)
        {
            var existingDog = await _repository.GetDogAsync(id);
            if (existingDog == null)
            {
                return false;
            }

            await _repository.DeleteDogAsync(id);
            return true;
        }
    }
}
