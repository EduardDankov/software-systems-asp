using System.ComponentModel.DataAnnotations;

namespace SoftwareSystems.Models;

public enum TaskPriority {
    Low,
    Normal,
    High,
    Urgent
}

public enum TaskStatus {
    Created,
    InProcess,
    Delayed,
    Canceled,
    Completed
}

public class Task
{
    public int TaskId { get; set; }
    
    [Required]
    public int ProjectId { get; set; }
    
    [Required]
    public int AssigneeId { get; set; }
    
    [Required]
    [MinLength(3)]
    [MaxLength(63)]
    public string? Name { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string? Description { get; set; }
    
    [Required]
    public TaskPriority Priority { get; set; }
    
    public TaskStatus Status { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    public DateTime Deadline { get; set; }
}