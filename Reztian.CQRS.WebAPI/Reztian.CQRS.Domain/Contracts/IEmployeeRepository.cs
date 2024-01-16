using Reztian.CQRS.Domain.Models;

namespace Reztian.CQRS.Domain.Contracts;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetAll();
    Task<IEnumerable<Employee>> GetAllByGender(bool gender);
    Task<Employee> GetOneById(int id);
    Task<int> Add(Employee employee);
    Task Delete(int id);
}