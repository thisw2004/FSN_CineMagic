using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineMagicData.Models;

[Table("room_movie")]
public class RoomMovie
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int RoomId { get; set; }
    
    [Required]
    public int MovieId { get; set; }

    [Required] 
    public DateTime DateTime { get; set; }
    //
    // public Room Room { get; set; }
    //
    // public Movie Movie { get; set; }
}

public class GetRoomMovie
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public int MovieId { get; set; }
    public DateTime DateTime { get; set; }
    public Room Room { get; set; }
    public Movie Movie { get; set; }
}

public class GroupedShows
{
    
    public DateTime DateTime { get; set; }

    public List<GetRoomMovie> Shows { get; set; }
}