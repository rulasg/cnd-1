using Demo.Models;

namespace Demo.Interfaces
{
    public interface IDogRepository
    {
        Task<IEnumerable<Dog>> GetDogsAsync();
        Task<Dog?> GetDogAsync(int id);
        Task AddDogAsync(Dog dog);
        Task UpdateDogAsync(Dog dog);
        Task DeleteDogAsync(int id);
    }
}
