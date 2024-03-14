using CineMagicData.Models;

namespace CineMagicData.Repositories;

public interface IRoomRepository
{
    Task<IEnumerable<Room>> GetRoomsAsync();
    Task<Room> GetRoomsByIdAsync(int id);
    Task<Room> CreateRoomAsync(Room room);
    Task UpdateRoomAsync(Room room);
    Task DeleteRoomAsync(Room room);
}