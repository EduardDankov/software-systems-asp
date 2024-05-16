using System.ComponentModel.DataAnnotations;

namespace SoftwareSystems.Models;

public class User
{
    public int UserId { get; set; }
    
    [Required]
    [MinLength(3)]
    [MaxLength(63)]
    public string? Username { get; set; }
    
    [Required]
    [MinLength(3)]
    [MaxLength(63)]
    public string? Email { get; set; }
    
    [Required]
    [MinLength(59)]
    [MaxLength(60)]
    public string? PasswordHash { get; set; }
}
