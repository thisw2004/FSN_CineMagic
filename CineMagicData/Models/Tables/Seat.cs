using System.ComponentModel.DataAnnotations.Schema;

namespace CineMagicData.Models;

using System.ComponentModel.DataAnnotations;

[Table("seat")]
public class Seat
{
    [Required]
    public int? SeatId { get; set; }
    
    [Required]
    public string? SeatNumber { get; set; }

    public int? RowNumber { get; set; }
    
    [ForeignKey("RoomId")]
    public int? RoomId { get; set; }
}