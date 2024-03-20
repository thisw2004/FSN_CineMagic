using CineMagicData.Models;

namespace CineMagicBlazor.Services;

public class ShowService
{
    private readonly HttpClient _httpClient;

    public ShowService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpResponseMessage> AddShow(RoomMovie show)
    {
        return await _httpClient.PostAsJsonAsync("api/shows/add", show);
    }
    
    public async Task<List<GroupedShows>> GetGroupedShows()
    {
        return await _httpClient.GetFromJsonAsync<List<GroupedShows>>("api/shows/all");
    }
}