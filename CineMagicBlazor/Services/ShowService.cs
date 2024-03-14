using CineMagicData.Models;

namespace CineMagic.Services;

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
}