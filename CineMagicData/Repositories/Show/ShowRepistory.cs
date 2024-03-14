using CineMagicData.Models;
using Microsoft.EntityFrameworkCore;

namespace CineMagicData.Repositories.Show;

public class ShowRepistory : IShowRepistory
{
    private readonly Contexts.RoomMovieContext _ctx;
    
    public ShowRepistory(Contexts.RoomMovieContext ctx)
    {
        _ctx = ctx;
    }
    
    public async Task<RoomMovie> CreateShowAsync(RoomMovie roomMovie)
    {
        _ctx.RoomMovie.Add(roomMovie);
        await _ctx.SaveChangesAsync();
        return roomMovie;
    }
    
    public async Task<RoomMovie> GetShowByIdAsync(int id)
    {
        return await _ctx.RoomMovie.FindAsync(id);
    }
}