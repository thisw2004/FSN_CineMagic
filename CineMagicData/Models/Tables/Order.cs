using System.ComponentModel.DataAnnotations.Schema;

namespace CineMagicData.Models;

using System.ComponentModel.DataAnnotations;

[Table("orders")]
public class Order
{
    [Required]
    public int OrderId { get; set; }
    
    public DateTime? Date { get; set; }

    public double? TotalAmount { get; set; }
    
    [Required]
    public string? Status { get; set; }
}