using System.ComponentModel.DataAnnotations.Schema;

namespace CineMagicData.Models;

using System.ComponentModel.DataAnnotations;

[Table("films")]
public class Movie
{
    public int Id { get; set; }
    
    public string Title { get; set; }

    public string Description { get; set; }

    public string? ShortDescription { get; set; }

    public string? Image { get; set; }

    public string? PegiRating { get; set; }

    public string? Genre { get; set; }

    public int? Length { get; set; }

    public string? Language { get; set; }
}