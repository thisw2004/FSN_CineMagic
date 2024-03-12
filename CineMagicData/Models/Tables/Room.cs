using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineMagicData.Models;

[Table("rooms")]
public class Room
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public int room_number { get; set; }

    public int amount_seats { get; set; }

    public int amount_rows { get; set; }

    public int size { get; set; }
}