using Demo.Models;

namespace Demo.Interfaces
{
    public interface IDogService
    {
        Task<IEnumerable<Dog>> GetDogsAsync();
        Task<Dog?> GetDogAsync(int id);
        Task AddDogAsync(Dog dog);
        Task<bool> UpdateDogAsync(Dog dog);
        Task<bool> DeleteDogAsync(int id);
    }
}
