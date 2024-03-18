using System.Text;
using System.Text.Json;

namespace CineMagicManagementPortal.Services;
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
    
    public async Task<Movie> GetMovieById(int movieId)
    {
        return await _httpClient.GetFromJsonAsync<Movie>($"api/movies/movie/{movieId}");
    }
    
    public async Task<IEnumerable<Movie>> SearchMovies(string searchTerm, string pegi, string genre)
    {
        var getUrl = $"api/movies/search?searchTerm={searchTerm}&pegi={pegi}&genre={genre}";
        var movies = await _httpClient.GetFromJsonAsync<IEnumerable<Movie>>(getUrl);
        return movies ?? new List<Movie>();
    }
}