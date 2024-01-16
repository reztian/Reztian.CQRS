using Microsoft.EntityFrameworkCore;
using Reztian.CQRS.Infrastructure.Database.Entities;

namespace Reztian.CQRS.Infrastructure.Database.Contexts;

public class CompanyDBContext : DbContext
{
    public CompanyDBContext(DbContextOptions<CompanyDBContext> options) : base(options) { }
    
    public virtual DbSet<Employee> Employees { get; set; }
}