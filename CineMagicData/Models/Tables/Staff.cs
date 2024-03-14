using System.ComponentModel.DataAnnotations.Schema;

namespace CineMagicData.Models;

using System.ComponentModel.DataAnnotations;

[Table("staff")]
public class Staff
{
    [Required]
    public int StaffId { get; set; }
    
    [Required]
    public string? Username { get; set; }

    [Required]
    public string? Password { get; set; }
    
    [Required]
    public string? FullName { get; set; }

    public DateTime? DateOfBirth { get; set; }
}
