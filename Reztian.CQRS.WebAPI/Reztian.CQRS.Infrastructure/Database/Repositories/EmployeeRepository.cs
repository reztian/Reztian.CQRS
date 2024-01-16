using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Reztian.CQRS.Domain.Contracts;
using Reztian.CQRS.Domain.Models;
using Reztian.CQRS.Infrastructure.Database.Contexts;

namespace Reztian.CQRS.Infrastructure.Database.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly CompanyDBContext _db;
    private readonly IMapper _mapper;

    public EmployeeRepository(CompanyDBContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<Employee>> GetAll()
    {
        return await _db.Employees
            .ProjectTo<Employee>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<IEnumerable<Employee>> GetAllByGender(bool gender)
    {
        return await _db.Employees
            .Where(t => t.Gender == gender)
            .ProjectTo<Employee>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
    public async Task<Employee> GetOneById(int id)
    {
        return await _db.Employees
            .Where(t => t.EmployeeId == id)
            .ProjectTo<Employee>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
    }

    public async Task<int> Add(Employee employee)
    {
        var entity = _mapper.Map<Entities.Employee>(employee);
        _db.Employees.Add(entity);
        await _db.SaveChangesAsync();

        return entity.EmployeeId;
    }

    public async Task Delete(int id)
    {
        var entity = await FindEmployeeById(id);
        _db.Employees.Remove(entity);
        await _db.SaveChangesAsync();
    }

    private async Task<Entities.Employee> FindEmployeeById(int id)
    {
        var found = await _db.Employees.FindAsync(id);
        if (found == null)
            throw new NullReferenceException();

        return found;
    }
}