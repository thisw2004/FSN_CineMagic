using CineMagicData.Models;

namespace CineMagic.Services;

public class RoomService
{
    private readonly HttpClient _httpClient;

    public RoomService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<HttpResponseMessage> AddRoom(Room room)
    {
        return await _httpClient.PostAsJsonAsync("api/rooms/add", room);
    }
}