using CineMagicData.Models;
using Microsoft.EntityFrameworkCore;

namespace CineMagicData.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly Contexts.MovieContext _ctx;
    
    public MovieRepository(Contexts.MovieContext ctx)
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
    
    public async Task<IEnumerable<Movie>> SearchMoviesAsync(string searchTerm = "", string pegi = "", string genre = "")
    {
        var query = _ctx.Movies.AsQueryable();

        if (!string.IsNullOrEmpty(searchTerm))
        {
            query = query.Where(m => m.Title.Contains(searchTerm));
        }

        if (!string.IsNullOrEmpty(pegi))
        {
            query = query.Where(m => m.PegiRating.Contains(pegi));
        }

        if (!string.IsNullOrEmpty(genre))
        {
            query = query.Where(m => m.Genre.Contains(genre));
        }

        return await query.ToListAsync();
    }
    
}