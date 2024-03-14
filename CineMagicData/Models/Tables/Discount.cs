using System.ComponentModel.DataAnnotations.Schema;

namespace CineMagicData.Models;

using System.ComponentModel.DataAnnotations;

[Table("discounts")]
public class Discounts
{
    [Required, Key]
    public int DiscountId { get; set; }
    
    [Required]
    public string?  Name { get; set; }

    [Required]
    public double ? Amount { get; set; }
}