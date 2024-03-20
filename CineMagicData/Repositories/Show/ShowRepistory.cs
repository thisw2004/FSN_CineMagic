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
    
    public async Task<List<GroupedShows>> GetAllShowsAsync()
    {
        
        var today = DateTime.Today;

        var daysUntil = ((int)DayOfWeek.Wednesday - (int)today.DayOfWeek + 7) % 7;
        if (daysUntil < 4)
        {
            daysUntil += 7;
        }
        
        var wednesday = today.AddDays(daysUntil);
        
        var shows =  await _ctx.RoomMovie
            .Where(rm => rm.DateTime >= today )
            .Where(rm => rm.DateTime <= wednesday)
            .ToListAsync();
        
        var groupedShows = shows
            .GroupBy(show => show.DateTime.Date)
            .Select(group => new GroupedShows
            {
                DateTime = group.Key,
                Shows = group.Select(show => new GetRoomMovie
                    {
                        Id = show.Id,
                        RoomId = show.RoomId,
                        MovieId = show.MovieId,
                        DateTime = show.DateTime,
                        Room = _ctx.Rooms.FirstOrDefault(r => r.Id == show.RoomId),
                        Movie = _ctx.Movies.FirstOrDefault(m => m.Id == show.MovieId)
                    })
                    .ToList()
            })
            .ToList();

        return groupedShows;

    }
}