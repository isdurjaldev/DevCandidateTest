using Microsoft.EntityFrameworkCore;

namespace DevCandidateTest;

public class EmployeesContext : DbContext
{
    public DbSet<Employee> Employee {get;set;}
    public EmployeesContext(DbContextOptions<EmployeesContext> options) : base(options) {}
}