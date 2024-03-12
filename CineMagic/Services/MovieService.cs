namespace CineMagic.Services;
using CineMagicData.Models;

public class MovieService
{
    private readonly HttpClient _httpClient;
    
    public MovieService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Movie>> GetAllMovies()
    {
        var movies = await _httpClient.GetFromJsonAsync<IEnumerable<Movie>>("api/movies/all");

        return movies ?? new List<Movie>();
    }
}