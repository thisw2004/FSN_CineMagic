using System.ComponentModel.DataAnnotations.Schema;

namespace CineMagicData.Models;

using System.ComponentModel.DataAnnotations;

[Table("actors")]
public class Actor
{
    [Required]
    public int ActorId { get; set; }
    
    [Required]
    public string?  Name { get; set; }

    public int? Age { get; set; }

    public string? Gender { get; set; }
}