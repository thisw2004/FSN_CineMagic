using CineMagicData.Models;

namespace CineMagicData.Repositories;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetMoviesAsync();
    Task<Movie> GetMoviesByIdAsync(int id);
    Task<Movie> CreateMovieAsync(Movie movie);
    Task UpdateMovieAsync(Movie movie);
    Task DeleteMovieAsync(Movie movie);
    Task<IEnumerable<Movie>> SearchMoviesAsync(string searchTerm, string pegi, string genre);
}