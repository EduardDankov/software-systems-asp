using System.ComponentModel.DataAnnotations;

namespace SoftwareSystems.Models;

public class Project
{
    public int ProjectId { get; set; }
    
    [Required]
    public int ManagerId { get; set; }
    
    [Required]
    [MinLength(3)]
    [MaxLength(63)]
    public string? Name { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string? Description { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}
