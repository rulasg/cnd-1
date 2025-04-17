using Microsoft.EntityFrameworkCore;
using Demo.Models;
using Demo.Data;

namespace Demo.Endpoints
{
    public static class DogEndpoints
    {
        public static void MapDogEndpoints(this WebApplication app)
        {
            app.MapGet("", () => "Hello, World!");

            app.MapGet("/dogs", async (DogContext db) =>
                await db.Dogs.ToListAsync());

            app.MapGet("/dogs/{id}", async (int id, DogContext db) =>
                await db.Dogs.FindAsync(id)
                    is Dog dog
                        ? Results.Ok(dog)
                        : Results.NotFound());

            app.MapPost("/dogs", async (Dog dog, DogContext db) =>
            {
                db.Dogs.Add(dog);
                await db.SaveChangesAsync();

                return Results.Created($"/dogs/{dog.Id}", dog);
            });

            app.MapPut("/dogs/{id}", async (int id, Dog inputDog, DogContext db) =>
            {
                var dog = await db.Dogs.FindAsync(id);

                if (dog is null) return Results.NotFound();

                dog.Name = inputDog.Name;
                dog.Breed = inputDog.Breed;
                dog.Owner = inputDog.Owner;

                await db.SaveChangesAsync();

                return Results.NoContent();
            });

            app.MapDelete("/dogs/{id}", async (int id, DogContext db) =>
            {
                if (await db.Dogs.FindAsync(id) is Dog dog)
                {
                    db.Dogs.Remove(dog);
                    await db.SaveChangesAsync();
                    return Results.Ok(dog);
                }

                return Results.NotFound();
            });
        }
    }
}
