using System.ComponentModel.DataAnnotations;

namespace DevCandidateTest;

public class Employee
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    [MaxLength(13)]
    public string RFC { get; set; }
    public DateTime BornDate { get; set; }
    public EmployeeStatus Status { get; set; }
}

public enum EmployeeStatus
{
    NotSet,
    Active,
    Inactive
}
