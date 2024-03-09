using CineMagicData.Models;
using Microsoft.EntityFrameworkCore;

namespace CineMagicData.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly MovieContext _ctx;
    
    public MovieRepository(MovieContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<IEnumerable<Movie>> GetMoviesAsync()
    {
        var movies = await _ctx.Movies.ToListAsync();
        return movies;
    }
    
    public async Task<Movie> GetMoviesByIdAsync(int id)
    {
         return await _ctx.Movies.FindAsync(id);
    }

    public async Task<Movie> CreateMovieAsync(Movie movie)
    {
        _ctx.Movies.Add(movie);
        await _ctx.SaveChangesAsync();
        return movie;
    }
    
    public async Task UpdateMovieAsync(Movie movie)
    {
        _ctx.Movies.Update(movie);
        await _ctx.SaveChangesAsync();
    }
    
    public async Task DeleteMovieAsync(Movie movie)
    {
        _ctx.Movies.Remove(movie);
        await _ctx.SaveChangesAsync();
    }
    
    
}