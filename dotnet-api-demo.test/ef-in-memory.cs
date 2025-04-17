using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Demo.Data;
using Demo.Models;

namespace Tests
{
    public class DogContextTests
    {
        public DogContextTests()
        {
        }

        [Fact]
        public void EF_InMemory()
        {

        }

        [Fact]
        public void WhenUserIsInsertedItCanBeSelected() 
        {
 
            var dog = new Dog
            {
                Id = 1,
                Name = "Buddy",
                Breed = "Golden Retriever",
                Owner = "John Doe"
            };

            var sut = GetInstance();

            sut.Dogs.Add(dog);
            sut.SaveChanges();

            var retrieved = sut.Dogs.First();
            Assert.Equal(dog, retrieved);
        }

        [Fact]
        public void GivenContextItMustBeEmpty()
        {
            var sut = GetInstance();
            Assert.Equal(0, sut.Dogs.Count());
        }

        private DogContext GetInstance()
        {
            var builder = new DbContextOptionsBuilder<DogContext>();
            builder.UseInMemoryDatabase("dogs");
            var context = new DogContext(builder.Options);
            context.Database.EnsureDeleted();  // as if having to have a method like this was not lame enough
            return context;
        }
    }
}