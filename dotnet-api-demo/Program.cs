using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Demo.Data;
using Demo.Services;
using Demo.Interfaces;
using Demo.Repositories;
using Demo.Models;
using Demo.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DogContext>();

// Register DogService and DogRepository
builder.Services.AddScoped<IDogService, DogService>();
builder.Services.AddScoped<IDogRepository, DogRepository>();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
});

var app = builder.Build();

// Seed the in-memory database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DogContext>();
    context.Dogs.AddRange(
        new Dog { Id = 1, Name = "Buddy", Breed = "Golden Retriever", Owner = "John Doe" },
        new Dog { Id = 2, Name = "Bella", Breed = "Labrador Retriever", Owner = "Emily Smith" },
        new Dog { Id = 3, Name = "Charlie", Breed = "Beagle", Owner = "Michael Johnson" },
        new Dog { Id = 4, Name = "Max", Breed = "German Shepherd", Owner = "Sarah Williams" },
        new Dog { Id = 5, Name = "Lucy", Breed = "Poodle", Owner = "David Brown" },
        new Dog { Id = 6, Name = "Daisy", Breed = "Bulldog", Owner = "Emma Jones" },
        new Dog { Id = 7, Name = "Bailey", Breed = "Boxer", Owner = "Daniel Garcia" },
        new Dog { Id = 8, Name = "Molly", Breed = "Rottweiler", Owner = "Sophia Martinez" },
        new Dog { Id = 9, Name = "Lola", Breed = "Dachshund", Owner = "James Rodriguez" },
        new Dog { Id = 10, Name = "Rocky", Breed = "Siberian Husky", Owner = "Olivia Hernandez" }
    );
    context.SaveChanges();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

//DogEndpoints.MapEndpoints(app);

app.Run();