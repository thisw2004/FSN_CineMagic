using System.Text;
using System.Text.Json;

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
    
    // public async Task<HttpResponseMessage> AddMovie(Movie movie)
    // {
    //     var jsonMovieContent = JsonSerializer.Serialize(movie);
    //     var jsonMovie = new StringContent(jsonMovieContent, Encoding.UTF8, "application/json");
    //
    //     HttpResponseMessage result = await _httpClient.PostAsync("api/movies/add", jsonMovie);
    //
    //     if (!result.IsSuccessStatusCode)
    //     {
    //         var error = await result.Content.ReadAsStringAsync();
    //         throw new Exception($"Error calling API. Status: {result.StatusCode}. Error: {error}");
    //     }
    //
    //     return result;
    // }
    
    
    public async Task<HttpResponseMessage> AddMovie(Movie movie)
    {
        return await _httpClient.PostAsJsonAsync("api/movies/add", movie);
    }
}