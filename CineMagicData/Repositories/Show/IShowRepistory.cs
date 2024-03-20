using CineMagicData.Models;

namespace CineMagicData.Repositories.Show;

public interface IShowRepistory
{
    Task<RoomMovie> CreateShowAsync(RoomMovie roomMovie);
    Task<RoomMovie> GetShowByIdAsync(int id);
    Task<List<GroupedShows>> GetAllShowsAsync();
    
}