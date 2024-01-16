using System.ComponentModel.DataAnnotations;

namespace Reztian.CQRS.Infrastructure.Database.Entities;

public class Employee
{
    [Key]
    public int EmployeeId { get; set; }
    [Required, MaxLength(50)]
    public string FirstName { get; set; }
    [Required, MaxLength(50)]
    public string LastName { get; set; }
    public bool Gender { get; set; }
    [Required, MaxLength(50)]
    public string Address { get; set; }
    public DateOnly Birthdate { get; set; }
}