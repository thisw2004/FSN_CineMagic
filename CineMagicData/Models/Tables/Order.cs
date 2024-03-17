using System.ComponentModel.DataAnnotations.Schema;
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
    
    [Required]
    public string? FullName { get; set; }
    
    [EmailAddress]
    public string? Email { get; set; }
    
    [Required]
    public string? CardholderName { get; set; }
    
    [Required, CreditCard]
    public string? CardNumber { get; set; }
    
    [Required]
    public DateTime? ExpiryDate { get; set; } // Stored as string to accommodate different formats
    
    [Required, RegularExpression(@"\d{3,4}", ErrorMessage = "CVV must be 3 or 4 digits.")]
    public string? CVV { get; set; }
    
    public string? SelectedBank { get; set; }
    
    public string? PaymentMethod { get; set; }
}