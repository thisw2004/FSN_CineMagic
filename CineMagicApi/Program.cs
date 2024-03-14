using CineMagicData.Models;
using CineMagicData.Repositories;
using CineMagicData.Repositories.Show;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Add all the necessary things for database connections for movies
builder.Services.AddTransient<Contexts.MovieContext>();
builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddDbContext<Contexts.MovieContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("default")));

//
builder.Services.AddTransient<Contexts.RoomMovieContext>();
builder.Services.AddTransient<IShowRepistory, ShowRepistory>();
builder.Services.AddDbContext<Contexts.RoomMovieContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("default")));

//Add all the necessary things for database connections for rooms

builder.Services.AddTransient<Contexts.RoomContext>();
builder.Services.AddTransient<IRoomRepository, RoomRepository>();
builder.Services.AddDbContext<Contexts.RoomContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("default")));

//Add the api controllers
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers(); // <--- Add this line to map the routes in MovieController

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

// app.MapGet("/weatherforecast", () =>
//     {
//         var forecast = Enumerable.Range(1, 5).Select(index =>
//                 new WeatherForecast
//                 (
//                     DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//                     Random.Shared.Next(-20, 55),
//                     summaries[Random.Shared.Next(summaries.Length)]
//                 ))
//             .ToArray();
//         return forecast;
//     })
//     .WithName("GetWeatherForecast")
//     .WithOpenApi();



app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}