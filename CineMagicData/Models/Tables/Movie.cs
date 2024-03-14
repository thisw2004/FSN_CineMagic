using System.ComponentModel.DataAnnotations.Schema;

namespace CineMagicData.Models;

using System.ComponentModel.DataAnnotations;

[Table("films")]
public class Movie
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    public string? Title { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public string? ShortDescription { get; set; }
    [Required]
    public string? Image { get; set; }
    [Required]
    public string? PegiRating { get; set; }
    [Required]
    public string? Genre { get; set; }
    [Required]
    public int? Length { get; set; }
    [Required]
    public string? Language { get; set; }
}