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
    // public Room Room { get; set; }
    
    [Required]
    public int MovieId { get; set; }
    // public Movie Movie { get; set; }

    [Required] 
    public DateTime DateTime { get; set; }
}