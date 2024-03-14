using CineMagicData.Models;
using Microsoft.EntityFrameworkCore;

namespace CineMagicData.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly Contexts.RoomContext _ctx;
    
    public RoomRepository(Contexts.RoomContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<IEnumerable<Room>> GetRoomsAsync()
    {
        var movies = await _ctx.Rooms.ToListAsync();
        return movies;
    }
    
    public async Task<Room> GetRoomsByIdAsync(int id)
    {
        return await _ctx.Rooms.FindAsync(id);
    }

    public async Task<Room> CreateRoomAsync(Room room)
    {
        _ctx.Rooms.Add(room);
        await _ctx.SaveChangesAsync();
        return room;
    }
    
    public async Task UpdateRoomAsync(Room room)
    {
        _ctx.Rooms.Update(room);
        await _ctx.SaveChangesAsync();
    }
    
    public async Task DeleteRoomAsync(Room room)
    {
        _ctx.Rooms.Remove(room);
        await _ctx.SaveChangesAsync();
    }}