namespace Reztian.CQRS.Domain.Models;

public class Employee
{
    public Employee(string firstName, string lastName, bool gender, string address, DateOnly birthdate)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Birthdate = birthdate;


    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }

    public bool Gender { get; set; }
    public DateOnly Birthdate { get; set; }
}